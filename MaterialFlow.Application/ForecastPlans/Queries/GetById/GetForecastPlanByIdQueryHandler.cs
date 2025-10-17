using MaterialFlow.Domain.ForecastPlans;

namespace MaterialFlow.Application.ForecastPlans.Queries.GetById;

internal sealed class GetForecastPlanByIdQueryHandler(IForecastPlanRepository forecastPlanRepository)
    : IRequestHandler<GetForecastPlanByIdQuery, Result<ForecastPlanResponse>>
{
    public async Task<Result<ForecastPlanResponse>> Handle(
        GetForecastPlanByIdQuery request,
        CancellationToken cancellationToken)
    {
        var forecastPlan = await forecastPlanRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (forecastPlan is null)
        {
            return Result.Failure<ForecastPlanResponse>(ForecastPlanErrors.NotFound);
        }

        var response = new ForecastPlanResponse(
            forecastPlan.Id,
            forecastPlan.MaterialId,
            forecastPlan.SiteId,
            forecastPlan.PlanningAreaId,
            forecastPlan.Version,
            forecastPlan.PlanningStrategy,
            forecastPlan.UnitOfMeasure.Value,
            forecastPlan.PeriodGranularity.Value,
            forecastPlan.DateRange.StartDate,
            forecastPlan.DateRange.EndDate);

        return Result.Success(response);
    }
}