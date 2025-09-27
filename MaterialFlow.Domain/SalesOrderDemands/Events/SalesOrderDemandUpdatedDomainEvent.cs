namespace MaterialFlow.Domain.SalesOrderDemands.Events;

public sealed record SalesOrderDemandUpdatedDomainEvent(Guid DemandId) : IDomainEvent;