namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanCreatedDomainEvent(Guid ForecastId) : IDomainEvent;