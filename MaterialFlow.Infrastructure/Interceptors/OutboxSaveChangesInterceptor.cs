using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json;

namespace MaterialFlow.Infrastructure.Interceptors;

public sealed class OutboxSaveChangesInterceptor : SaveChangesInterceptor
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not DbContext dbContext)
        {
            return base.SavingChangesAsync(
                eventData,
                result,
                cancellationToken);
        }

        var domainEvents = ExtractDomainEvents(dbContext);

        if (domainEvents is { Count: 0 })
        {
            return base.SavingChangesAsync(
                eventData,
                result,
                cancellationToken);
        }

        AddOutboxMessages(
            dbContext,
            domainEvents);

        return base.SavingChangesAsync(
            eventData,
            result,
            cancellationToken);
    }

    private static List<IDomainEvent> ExtractDomainEvents(DbContext dbContext)
    {
        var domainEvents = dbContext.ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var events = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return events;
            })
            .ToList();

        return domainEvents;
    }

    private static void AddOutboxMessages(
        DbContext dbContext,
        List<IDomainEvent> domainEvents)
    {
        var outboxMessages = domainEvents
            .Select(domainEvent => OutboxMessage.Create(
                DateTime.UtcNow,
                domainEvent.GetType().AssemblyQualifiedName!,
                JsonSerializer.Serialize(
                    domainEvent,
                    domainEvent.GetType(), SerializerOptions)))
            .ToList();

        dbContext.Set<OutboxMessage>().AddRange(outboxMessages);
    }
}