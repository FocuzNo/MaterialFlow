namespace MaterialFlow.Application.PlanningRunLines.Queries.GetAll;

public sealed record GetAllPlanningRunLinesQuery : IRequest<Result<IReadOnlyCollection<PlanningRunLineResponse>>>;