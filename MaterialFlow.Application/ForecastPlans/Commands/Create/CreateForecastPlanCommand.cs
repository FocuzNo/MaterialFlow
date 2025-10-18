namespace MaterialFlow.Application.ForecastPlans.Commands.Create;

public sealed record CreateForecastPlanCommand(
    Guid MaterialId,
    Guid? SiteId,
    Guid? PlanningAreaId,
    string Version,
    string PlanningStrategy,
    string UnitOfMeasure,
    int PeriodGranularity,
    DateOnly StartDate,
    DateOnly EndDate) : IRequest<Guid>;
