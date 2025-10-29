using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;

namespace MaterialFlow.Infrastructure.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxMessagesJob(
    IDbContextFactory<ApplicationDbContext> applicationDbContextFactory,
    IPublisher mediatorPublisher,
    IOptions<OutboxOptions> outboxOptionsAccessor,
    ILogger<ProcessOutboxMessagesJob> processOutboxMessagesJobLogger) : IJob
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly OutboxOptions outboxOptions = outboxOptionsAccessor.Value;

    public async Task Execute(IJobExecutionContext quartzJobExecutionContext)
    {
        await using var dbContext = await applicationDbContextFactory
            .CreateDbContextAsync(quartzJobExecutionContext.CancellationToken);

        var outboxMessages = await dbContext.OutboxMessages
            .Where(outboxMessage => outboxMessage.ProcessedOnUtc == null)
            .OrderBy(outboxMessage => outboxMessage.OccurredOnUtc)
            .Take(outboxOptions.BatchSize)
            .ToListAsync(quartzJobExecutionContext.CancellationToken);

        foreach (var outboxMessage in outboxMessages)
        {
            try
            {
                var domainEventType = ResolveDomainEventType(outboxMessage);

                var domainEventObject = JsonSerializer.Deserialize(
                    outboxMessage.Content,
                    domainEventType,
                    JsonSerializerOptions);

                if (domainEventObject is not INotification domainEventNotification)
                {
                    throw new InvalidOperationException($"Event is not INotification: {outboxMessage.Type ?? "(null)"}");
                }

                await mediatorPublisher.Publish(
                    domainEventNotification,
                    quartzJobExecutionContext.CancellationToken);

                outboxMessage.ProcessedOnUtc = DateTime.UtcNow;
                outboxMessage.Error = null;
            }
            catch (Exception exception)
            {
                outboxMessage.Error = exception.ToString();
                processOutboxMessagesJobLogger.LogWarning(exception, "Failed to process outbox message {MessageId}", outboxMessage.Id);
            }
        }

        await dbContext.SaveChangesAsync(quartzJobExecutionContext.CancellationToken);
    }

    private static Type ResolveDomainEventType(OutboxMessage outboxMessage)
    {
        if (!string.IsNullOrWhiteSpace(outboxMessage.Type))
        {
            var resolvedByTypeField = Type.GetType(
                outboxMessage.Type!,
                throwOnError: false);

            if (resolvedByTypeField is not null)
            {
                return resolvedByTypeField;
            }
        }

        using var jsonDocument = JsonDocument.Parse(outboxMessage.Content);

        if (jsonDocument.RootElement.TryGetProperty(
            "$type",
            out var typeProperty))
        {
            var resolvedByDiscriminator = Type.GetType(
                typeProperty.GetString()!,
                throwOnError: false);

            if (resolvedByDiscriminator is not null)
            {
                return resolvedByDiscriminator;
            }
        }

        throw new InvalidOperationException($"Cannot resolve event type for outbox message {outboxMessage.Id}");
    }
}
