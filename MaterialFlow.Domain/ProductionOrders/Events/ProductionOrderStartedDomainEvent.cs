namespace MaterialFlow.Domain.ProductionOrders.Events;

public sealed record ProductionOrderStartedDomainEvent(Guid OrderId) : IDomainEvent;