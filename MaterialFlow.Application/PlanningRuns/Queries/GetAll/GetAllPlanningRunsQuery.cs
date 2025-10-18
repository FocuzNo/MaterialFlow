namespace MaterialFlow.Application.PlanningRuns.Queries.GetAll;

public sealed record GetAllPlanningRunsQuery : IRequest<Result<IReadOnlyCollection<PlanningRunResponse>>>;