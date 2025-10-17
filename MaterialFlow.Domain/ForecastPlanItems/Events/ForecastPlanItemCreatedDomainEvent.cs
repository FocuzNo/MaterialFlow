namespace MaterialFlow.Domain.ForecastPlanItems.Events;

public sealed record ForecastPlanItemCreatedDomainEvent(
    Guid ItemId,
    Guid ForecastPlanId) : IDomainEvent;