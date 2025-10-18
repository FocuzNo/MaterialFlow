namespace MaterialFlow.Application.ForecastPlanItems.Commands.Create;

public sealed record CreateForecastPlanItemCommand(
    Guid ForecastPlanId,
    DateOnly PeriodStartDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string? ConsumptionIndicator) : IRequest<Guid>;