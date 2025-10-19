namespace MaterialFlow.Application.PlanningRuns.Commands.Update;

public sealed record UpdatePlanningRunCommand(
    Guid Id,
    int PlanningHorizonInDays,
    int OrderStatus) : IRequest<Result>;