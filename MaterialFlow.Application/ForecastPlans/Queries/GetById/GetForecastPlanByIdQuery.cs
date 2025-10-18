namespace MaterialFlow.Application.ForecastPlans.Queries.GetById;

public sealed record GetForecastPlanByIdQuery(Guid Id) : IRequest<Result<ForecastPlanResponse>>;