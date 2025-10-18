namespace MaterialFlow.Application.PlanningAreas.Commands.Update;

public sealed record UpdatePlanningAreaCommand(
    Guid Id,
    string PlanningAreaCode,
    string Description,
    Guid SiteId) : IRequest<Result>;