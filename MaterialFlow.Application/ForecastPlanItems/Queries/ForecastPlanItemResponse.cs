namespace MaterialFlow.Application.ForecastPlanItems.Queries;

public sealed record ForecastPlanItemResponse(
    Guid Id,
    Guid ForecastPlanId,
    DateOnly PeriodStartDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string? ConsumptionIndicator);