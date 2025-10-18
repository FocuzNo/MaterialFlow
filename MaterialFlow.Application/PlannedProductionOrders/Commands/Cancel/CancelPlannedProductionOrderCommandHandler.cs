using MaterialFlow.Domain.PlannedProductionOrders;

namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Cancel;

internal sealed class CancelPlannedProductionOrderCommandHandler(
    IPlannedProductionOrderRepository plannedProductionOrderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CancelPlannedProductionOrderCommand, Result>
{
    public async Task<Result> Handle(
        CancelPlannedProductionOrderCommand request,
        CancellationToken cancellationToken)
    {
        var plannedProductionOrder = await plannedProductionOrderRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (plannedProductionOrder is null)
        {
            return Result.Failure(PlannedProductionOrderErrors.NotFound);
        }

        plannedProductionOrder.Cancel();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}