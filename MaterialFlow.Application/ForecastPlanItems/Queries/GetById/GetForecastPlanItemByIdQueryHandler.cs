using MaterialFlow.Domain.ForecastPlanItems;

namespace MaterialFlow.Application.ForecastPlanItems.Queries.GetById;

internal sealed class GetForecastPlanItemByIdQueryHandler(IForecastPlanItemRepository forecastPlanItemRepository)
    : IRequestHandler<GetForecastPlanItemByIdQuery, Result<ForecastPlanItemResponse>>
{
    public async Task<Result<ForecastPlanItemResponse>> Handle(
        GetForecastPlanItemByIdQuery request,
        CancellationToken cancellationToken)
    {
        var forecastPlanItem = await forecastPlanItemRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (forecastPlanItem is null)
        {
            return Result.Failure<ForecastPlanItemResponse>(ForecastPlanItemErrors.NotFound);
        }

        var response = new ForecastPlanItemResponse(
            forecastPlanItem.Id,
            forecastPlanItem.ForecastPlanId,
            forecastPlanItem.PeriodStartDate,
            forecastPlanItem.Quantity.Amount,
            forecastPlanItem.Quantity.UnitOfMeasure.Value,
            forecastPlanItem.ConsumptionIndicator);

        return Result.Success(response);
    }
}