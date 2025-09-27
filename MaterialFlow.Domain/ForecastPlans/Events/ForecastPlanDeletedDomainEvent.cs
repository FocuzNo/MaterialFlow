namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanDeletedDomainEvent(Guid ForecastId) : IDomainEvent;