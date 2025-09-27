namespace MaterialFlow.Domain.ProductionOrders.Events;

public sealed record ProductionOrderUpdatedDomainEvent(Guid OrderId) : IDomainEvent;