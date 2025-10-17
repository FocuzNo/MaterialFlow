using MaterialFlow.Domain.ForecastPlanItems;

namespace MaterialFlow.Application.ForecastPlanItems.Commands.Create;

internal sealed class CreateForecastPlanItemCommandHandler(
    IForecastPlanItemRepository forecastPlanItemRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateForecastPlanItemCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateForecastPlanItemCommand request,
        CancellationToken cancellationToken)
    {
        var forecastPlanItem = ForecastPlanItem.Create(
            Guid.NewGuid(),
            request.ForecastPlanId,
            request.PeriodStartDate,
            new Quantity(
                request.Quantity,
                new UnitOfMeasure(request.UnitOfMeasure)),
            request.ConsumptionIndicator);

        await forecastPlanItemRepository.AddAsync(
            forecastPlanItem,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return forecastPlanItem.Id;
    }
}