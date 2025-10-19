namespace MaterialFlow.Application.PlanningRunLines.Queries.GetById;

public sealed record GetPlanningRunLineByIdQuery(Guid Id) : IRequest<Result<PlanningRunLineResponse>>;