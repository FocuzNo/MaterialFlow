using System.Text.Json;
using MaterialFlow.Application.Exceptions;
using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Infrastructure.Outbox;

namespace MaterialFlow.Infrastructure;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> dbContextOptions)
    : DbContext(dbContextOptions), IUnitOfWork
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            EnqueueOutboxMessages();

            var saveResult = await base.SaveChangesAsync(cancellationToken);

            return saveResult;
        }
        catch (DbUpdateConcurrencyException exception)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", exception);
        }
    }

    private void EnqueueOutboxMessages()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var eventsForEntity = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return eventsForEntity;
            })
            .ToList();

        if (domainEvents is { Count: 0 })
        {
            return;
        }

        var outboxMessages = domainEvents
            .Select(domainEvent =>
            {
                var typeName = domainEvent.GetType().AssemblyQualifiedName!;
                var content = System.Text.Json.JsonSerializer.Serialize(
                    domainEvent,
                    domainEvent.GetType(),
                    JsonSerializerOptions);

                var occurredOnUtc = DateTime.UtcNow;

                return OutboxMessage.Create(
                    occurredOnUtc,
                    typeName,
                    content);
            })
            .ToList();

        OutboxMessages.AddRange(outboxMessages);
    }
}