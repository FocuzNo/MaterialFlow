namespace MaterialFlow.Domain.SalesOrderDemands.Events;

public sealed record SalesOrderDemandCreatedDomainEvent(Guid DemandId) : IDomainEvent;
