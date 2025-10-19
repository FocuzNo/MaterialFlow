namespace MaterialFlow.Application.PlanningAreas.Commands.Create;

public sealed record CreatePlanningAreaCommand(
    string PlanningAreaCode,
    string Description,
    Guid SiteId) : IRequest<Guid>;