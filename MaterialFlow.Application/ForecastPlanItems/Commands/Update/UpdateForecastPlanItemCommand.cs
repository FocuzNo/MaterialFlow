namespace MaterialFlow.Application.ForecastPlanItems.Commands.Update;

public sealed record UpdateForecastPlanItemCommand(
    Guid Id,
    DateOnly PeriodStartDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string? ConsumptionIndicator) : IRequest<Result>;