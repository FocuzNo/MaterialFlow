namespace MaterialFlow.Application.ForecastPlanItems.Commands.Update;

public sealed record UpdateForecastPlanItemCommand(
    Guid Id,
    DateOnly PeriodStartDate,
    decimal Quantity,
    string UnitOfMeasure,
    string? ConsumptionIndicator) : IRequest<Result>;