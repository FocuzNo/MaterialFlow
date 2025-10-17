namespace MaterialFlow.Application.ForecastPlans.Commands.Delete;

public sealed record DeleteForecastPlanCommand(Guid Id) : IRequest<Result>;