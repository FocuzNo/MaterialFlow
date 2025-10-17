namespace MaterialFlow.Application.ForecastPlans.Commands.Update;

public sealed record UpdateForecastPlanCommand(
    Guid Id,
    string Version,
    string PlanningStrategy,
    string UnitOfMeasure,
    int PeriodGranularity,
    DateOnly StartDate,
    DateOnly EndDate) : IRequest<Result>;