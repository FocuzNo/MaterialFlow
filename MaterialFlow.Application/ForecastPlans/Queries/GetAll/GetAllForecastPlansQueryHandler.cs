using MaterialFlow.Domain.ForecastPlans;

namespace MaterialFlow.Application.ForecastPlans.Queries.GetAll;

internal sealed class GetAllForecastPlansQueryHandler(IForecastPlanRepository forecastPlanRepository)
    : IRequestHandler<GetAllForecastPlansQuery, Result<IReadOnlyCollection<ForecastPlanResponse>>>
{
    public async Task<Result<IReadOnlyCollection<ForecastPlanResponse>>> Handle(
        GetAllForecastPlansQuery request,
        CancellationToken cancellationToken)
    {
        var forecastPlans = await forecastPlanRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<ForecastPlanResponse>)[.. forecastPlans
            .Select(x => new ForecastPlanResponse(
                x.Id,
                x.MaterialId,
                x.SiteId,
                x.PlanningAreaId,
                x.Version,
                x.PlanningStrategy,
                x.UnitOfMeasure.Value,
                x.PeriodGranularity.Value,
                x.DateRange.StartDate,
                x.DateRange.EndDate)
            )]);
    }
}