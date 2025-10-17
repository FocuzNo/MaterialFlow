using MaterialFlow.Domain.ForecastPlanItems;

namespace MaterialFlow.Application.ForecastPlanItems.Commands.Delete;

internal sealed class DeleteForecastPlanItemCommandHandler(
    IForecastPlanItemRepository forecastPlanItemRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteForecastPlanItemCommand, Result>
{
    public async Task<Result> Handle(
        DeleteForecastPlanItemCommand request,
        CancellationToken cancellationToken)
    {
        var forecastPlanItem = await forecastPlanItemRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (forecastPlanItem is null)
        {
            return Result.Failure(ForecastPlanItemErrors.NotFound);
        }

        forecastPlanItem.Delete();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}