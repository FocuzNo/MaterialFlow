namespace MaterialFlow.Application.ForecastPlanItems.Commands.Delete;

public sealed record DeleteForecastPlanItemCommand(Guid Id) : IRequest<Result>;