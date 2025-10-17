namespace MaterialFlow.Application.ForecastPlans.Queries.GetAll;

public sealed record GetAllForecastPlansQuery : IRequest<Result<IReadOnlyCollection<ForecastPlanResponse>>>;
