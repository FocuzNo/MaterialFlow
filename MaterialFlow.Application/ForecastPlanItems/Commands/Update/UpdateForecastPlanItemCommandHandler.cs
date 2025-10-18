using MaterialFlow.Domain.ForecastPlanItems;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Application.ForecastPlanItems.Commands.Update;

internal sealed class UpdateForecastPlanItemCommandHandler(
    IForecastPlanItemRepository forecastPlanItemRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateForecastPlanItemCommand, Result>
{
    public async Task<Result> Handle(
        UpdateForecastPlanItemCommand request,
        CancellationToken cancellationToken)
    {
        var forecastPlanItem = await forecastPlanItemRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (forecastPlanItem is null)
        {
            return Result.Failure(ForecastPlanItemErrors.NotFound);
        }

        forecastPlanItem.Update(
            request.PeriodStartDate,
            new Quantity(
                request.QuantityAmount,
                new UnitOfMeasure(request.QuantityUnitOfMeasure)),
            request.ConsumptionIndicator);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}