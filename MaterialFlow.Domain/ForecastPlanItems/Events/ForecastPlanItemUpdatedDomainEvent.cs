namespace MaterialFlow.Domain.ForecastPlanItems.Events;

public sealed record ForecastPlanItemUpdatedDomainEvent(
    Guid ItemId,
    Guid ForecastPlanId) : IDomainEvent;