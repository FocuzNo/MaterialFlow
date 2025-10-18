namespace MaterialFlow.Application.PlanningAreas.Commands.Delete;

public sealed record DeletePlanningAreaCommand(Guid Id) : IRequest<Result>;