using MaterialFlow.Domain.ProductionOrders;

namespace MaterialFlow.Application.ProductionOrders.Commands.Cancel;

internal sealed class CancelProductionOrderCommandHandler(
    IProductionOrderRepository productionOrderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CancelProductionOrderCommand, Result>
{
    public async Task<Result> Handle(
        CancelProductionOrderCommand request,
        CancellationToken cancellationToken)
    {
        var productionOrder = await productionOrderRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productionOrder is null)
        {
            return Result.Failure(ProductionOrderErrors.NotFound);
        }

        productionOrder.Cancel();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}