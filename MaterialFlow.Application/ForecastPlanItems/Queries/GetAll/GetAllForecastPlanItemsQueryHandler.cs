using MaterialFlow.Domain.ForecastPlans;

namespace MaterialFlow.Application.ForecastPlanItems.Queries.GetAll;

internal sealed class GetAllForecastPlanItemsQueryHandler(IForecastPlanItemRepository forecastPlanItemRepository)
    : IRequestHandler<GetAllForecastPlanItemsQuery, Result<IReadOnlyCollection<ForecastPlanItemResponse>>>
{
    public async Task<Result<IReadOnlyCollection<ForecastPlanItemResponse>>> Handle(
        GetAllForecastPlanItemsQuery request,
        CancellationToken cancellationToken)
    {
        var forecastPlanItems = await forecastPlanItemRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<ForecastPlanItemResponse>)[.. forecastPlanItems
            .Select(x => new ForecastPlanItemResponse(
                x.Id,
                x.ForecastPlanId,
                x.PeriodStartDate,
                x.Quantity.Amount,
                x.Quantity.UnitOfMeasure.Value,
                x.ConsumptionIndicator)
            )]);
    }
}