namespace MaterialFlow.Application.ForecastPlanItems.Queries;

public sealed record ForecastPlanItemResponse(
    Guid Id,
    Guid ForecastPlanId,
    DateOnly PeriodStartDate,
    decimal Quantity,
    string UnitOfMeasure,
    string? ConsumptionIndicator);