namespace MaterialFlow.Application.PlanningRuns.Queries.GetById;

public sealed record GetPlanningRunByIdQuery(Guid Id) : IRequest<Result<PlanningRunResponse>>;