namespace MaterialFlow.Application.PlanningAreas.Queries.GetAll;

public sealed record GetAllPlanningAreasQuery : IRequest<Result<IReadOnlyCollection<PlanningAreaResponse>>>;