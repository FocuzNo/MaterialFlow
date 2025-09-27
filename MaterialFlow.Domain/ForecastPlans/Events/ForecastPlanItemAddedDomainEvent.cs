namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanItemAddedDomainEvent(
    Guid ForecastPlanId,
    Guid ItemId) : IDomainEvent;