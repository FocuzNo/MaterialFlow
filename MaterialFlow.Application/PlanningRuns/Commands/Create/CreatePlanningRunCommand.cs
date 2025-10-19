namespace MaterialFlow.Application.PlanningRuns.Commands.Create;

public sealed record CreatePlanningRunCommand(
    Guid? SiteId,
    Guid? PlanningAreaId,
    int PlanningHorizonInDays,
    string StartedByUser,
    int OrderStatus) : IRequest<Guid>;