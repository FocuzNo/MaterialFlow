namespace MaterialFlow.Domain.ProductionOrders.Events;

public sealed record ProductionOrderCreatedDomainEvent(Guid OrderId) : IDomainEvent;