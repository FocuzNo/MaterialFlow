namespace MaterialFlow.Application.PlanningRuns.Queries;

public sealed record PlanningRunResponse(
    Guid Id,
    DateTime RunTimestampUtc,
    Guid? SiteId,
    Guid? PlanningAreaId,
    int PlanningHorizonInDays,
    string StartedByUser,
    string OrderStatus,
    int LinesCount);