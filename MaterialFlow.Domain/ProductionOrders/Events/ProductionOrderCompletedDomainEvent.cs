namespace MaterialFlow.Domain.ProductionOrders.Events;

public sealed record ProductionOrderCompletedDomainEvent(Guid OrderId) : IDomainEvent;