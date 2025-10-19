using MaterialFlow.Domain.ProductionOrders;

namespace MaterialFlow.Application.ProductionOrders.Commands.Create;

internal sealed class CreateProductionOrderCommandHandler(
    IProductionOrderRepository productionOrderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateProductionOrderCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateProductionOrderCommand request,
        CancellationToken cancellationToken)
    {
        var productionOrder = ProductionOrder.Create(
            Guid.NewGuid(),
            request.MaterialId,
            request.SiteId,
            request.PlannedProductionOrderId,
            new Quantity(
                request.QuantityToProduceAmount,
                new UnitOfMeasure(request.QuantityToProduceUnitOfMeasure)),
            new UnitOfMeasure(request.UnitOfMeasure),
            request.ScheduledStartDate,
            request.ScheduledEndDate,
            OrderStatus.FromValue(request.OrderStatus));

        await productionOrderRepository.AddAsync(
            productionOrder,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return productionOrder.Id;
    }
}