namespace MaterialFlow.Domain.ForecastPlanItems.Events;

public sealed record ForecastPlanItemAddedDomainEvent(
    Guid ForecastPlanId,
    Guid ItemId) : IDomainEvent;