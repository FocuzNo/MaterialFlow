namespace MaterialFlow.Application.ForecastPlans.Queries;

public sealed record ForecastPlanResponse(
    Guid Id,
    Guid MaterialId,
    Guid? SiteId,
    Guid? PlanningAreaId,
    string Version,
    string PlanningStrategy,
    string UnitOfMeasure,
    int PeriodGranularity,
    DateOnly StartDate,
    DateOnly EndDate);