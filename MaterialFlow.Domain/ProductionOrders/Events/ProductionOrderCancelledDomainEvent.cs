namespace MaterialFlow.Domain.ProductionOrders.Events;

public sealed record ProductionOrderCancelledDomainEvent(Guid OrderId) : IDomainEvent;