namespace MaterialFlow.Application.PlanningAreas.Queries.GetById;

public sealed record GetPlanningAreaByIdQuery(Guid Id) : IRequest<Result<PlanningAreaResponse>>;