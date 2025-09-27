namespace MaterialFlow.Domain.PlannedProductionOrders.Events;

public sealed record PlannedProductionOrderApprovedDomainEvent(Guid PlannedOrderId) : IDomainEvent;