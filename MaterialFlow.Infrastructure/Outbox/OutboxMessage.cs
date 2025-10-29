using MaterialFlow.Domain.Abstractions;

namespace MaterialFlow.Infrastructure.Outbox;

public sealed class OutboxMessage : Entity
{
    private OutboxMessage() { }

    public DateTime OccurredOnUtc { get; set; }

    public string Type { get; set; } = default!;

    public string Content { get; set; } = default!;

    public DateTime? ProcessedOnUtc { get; set; }

    public string? Error { get; set; }

    public static OutboxMessage Create(
        DateTime occurredOnUtc,
        string type,
        string content)
    {
        return new()
        {
            OccurredOnUtc = occurredOnUtc,
            Type = type,
            Content = content
        };
    }
}