namespace MaterialFlow.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public Guid Id { get; protected init; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return [.. _domainEvents];
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
