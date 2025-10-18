namespace MaterialFlow.Application.PlanningRunLines.Commands.Delete;

public sealed record DeletePlanningRunLineCommand(Guid Id) : IRequest<Result>;