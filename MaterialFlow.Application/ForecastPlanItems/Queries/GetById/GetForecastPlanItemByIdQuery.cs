namespace MaterialFlow.Application.ForecastPlanItems.Queries.GetById;

public sealed record GetForecastPlanItemByIdQuery(Guid Id) : IRequest<Result<ForecastPlanItemResponse>>;