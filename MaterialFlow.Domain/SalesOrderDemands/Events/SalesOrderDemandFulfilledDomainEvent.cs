namespace MaterialFlow.Domain.SalesOrderDemands.Events;

public sealed record SalesOrderDemandFulfilledDomainEvent(
    Guid DemandId,
    Guid ProductionOrderId) : IDomainEvent;