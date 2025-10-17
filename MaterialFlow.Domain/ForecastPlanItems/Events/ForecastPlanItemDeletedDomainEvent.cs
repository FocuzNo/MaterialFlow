namespace MaterialFlow.Domain.ForecastPlanItems.Events;

public sealed record ForecastPlanItemDeletedDomainEvent(Guid ItemId, Guid ForecastPlanId) : IDomainEvent;