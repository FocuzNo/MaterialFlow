using MaterialFlow.Domain.ProductionOrders;

namespace MaterialFlow.Application.ProductionOrders.Commands.Update;

internal sealed class UpdateProductionOrderCommandHandler(
    IProductionOrderRepository productionOrderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductionOrderCommand, Result>
{
    public async Task<Result> Handle(
        UpdateProductionOrderCommand request,
        CancellationToken cancellationToken)
    {
        var productionOrder = await productionOrderRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productionOrder is null)
        {
            return Result.Failure(ProductionOrderErrors.NotFound);
        }

        productionOrder.Update(
            new Quantity(
                request.QuantityToProduceAmount,
                new UnitOfMeasure(request.QuantityToProduceUnitOfMeasure)),
            request.ScheduledStartDate,
            request.ScheduledEndDate,
            OrderStatus.FromValue(request.OrderStatus));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}