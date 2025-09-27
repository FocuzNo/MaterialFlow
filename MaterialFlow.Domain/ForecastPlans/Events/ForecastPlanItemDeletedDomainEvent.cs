namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanItemDeletedDomainEvent(Guid ItemId, Guid ForecastPlanId) : IDomainEvent;