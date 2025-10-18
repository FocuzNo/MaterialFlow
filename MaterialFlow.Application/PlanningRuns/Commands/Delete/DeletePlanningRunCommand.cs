namespace MaterialFlow.Application.PlanningRuns.Commands.Delete;

public sealed record DeletePlanningRunCommand(Guid Id) : IRequest<Result>;