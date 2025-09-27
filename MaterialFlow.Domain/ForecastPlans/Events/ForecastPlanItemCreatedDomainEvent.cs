namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanItemCreatedDomainEvent(
    Guid ItemId,
    Guid ForecastPlanId) : IDomainEvent;