namespace MaterialFlow.Application.ForecastPlanItems.Queries.GetAll;

public sealed record GetAllForecastPlanItemsQuery : IRequest<Result<IReadOnlyCollection<ForecastPlanItemResponse>>>;