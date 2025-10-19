namespace MaterialFlow.Application.PlanningAreas.Queries;

public sealed record PlanningAreaResponse(
    Guid Id,
    string PlanningAreaCode,
    string Description,
    Guid SiteId);