namespace MaterialFlow.Domain.PlannedProductionOrders.Events;

public sealed record PlannedProductionOrderCreatedDomainEvent(Guid PlannedOrderId) : IDomainEvent;