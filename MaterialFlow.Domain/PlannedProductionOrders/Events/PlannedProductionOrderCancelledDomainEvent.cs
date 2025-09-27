namespace MaterialFlow.Domain.PlannedProductionOrders.Events;

public sealed record PlannedProductionOrderCancelledDomainEvent(Guid PlannedOrderId) : IDomainEvent;