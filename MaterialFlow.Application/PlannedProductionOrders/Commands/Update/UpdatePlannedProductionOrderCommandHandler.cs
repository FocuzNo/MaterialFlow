using MaterialFlow.Domain.PlannedProductionOrders;

namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Update;

internal sealed class UpdatePlannedProductionOrderCommandHandler(
    IPlannedProductionOrderRepository plannedProductionOrderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePlannedProductionOrderCommand, Result>
{
    public async Task<Result> Handle(
        UpdatePlannedProductionOrderCommand request,
        CancellationToken cancellationToken)
    {
        var plannedProductionOrder = await plannedProductionOrderRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (plannedProductionOrder is null)
        {
            return Result.Failure(PlannedProductionOrderErrors.NotFound);
        }

        plannedProductionOrder.Update(
            request.Quantity,
            request.StartDate,
            request.EndDate,
            OrderStatus.FromValue(request.OrderStatus));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}