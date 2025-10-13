namespace MaterialFlow.Application.ForecastPlanItems.Commands.Create;

public sealed record CreateForecastPlanItemCommand(
    Guid ForecastPlanId,
    DateOnly PeriodStartDate,
    decimal Quantity,
    string UnitOfMeasure,
    string? ConsumptionIndicator) : IRequest<Guid>;