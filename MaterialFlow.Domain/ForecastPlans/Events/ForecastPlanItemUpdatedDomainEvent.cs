namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanItemUpdatedDomainEvent(
    Guid ItemId,
    Guid ForecastPlanId) : IDomainEvent;