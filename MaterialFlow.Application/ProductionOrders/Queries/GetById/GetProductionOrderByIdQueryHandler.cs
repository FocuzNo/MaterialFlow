using MaterialFlow.Domain.ProductionOrders;

namespace MaterialFlow.Application.ProductionOrders.Queries.GetById;

internal sealed class GetProductionOrderByIdQueryHandler(IProductionOrderRepository productionOrderRepository)
    : IRequestHandler<GetProductionOrderByIdQuery, Result<ProductionOrderResponse>>
{
    public async Task<Result<ProductionOrderResponse>> Handle(
        GetProductionOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var productionOrder = await productionOrderRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productionOrder is null)
        {
            return Result.Failure<ProductionOrderResponse>(ProductionOrderErrors.NotFound);
        }

        var response = new ProductionOrderResponse(
            productionOrder.Id,
            productionOrder.MaterialId,
            productionOrder.SiteId,
            productionOrder.PlannedProductionOrderId,
            productionOrder.QuantityToProduce.Amount,
            productionOrder.QuantityToProduce.UnitOfMeasure.Value,
            productionOrder.UnitOfMeasure.Value,
            productionOrder.ScheduledStartDate,
            productionOrder.ScheduledEndDate,
            productionOrder.OrderStatus.Name);

        return Result.Success(response);
    }
}