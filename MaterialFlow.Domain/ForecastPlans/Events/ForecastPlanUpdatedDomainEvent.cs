namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanUpdatedDomainEvent(Guid ForecastId) : IDomainEvent;