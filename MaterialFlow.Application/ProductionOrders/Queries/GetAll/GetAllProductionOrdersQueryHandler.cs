using MaterialFlow.Domain.ProductionOrders;

namespace MaterialFlow.Application.ProductionOrders.Queries.GetAll;

internal sealed class GetAllProductionOrdersQueryHandler(IProductionOrderRepository productionOrderRepository)
    : IRequestHandler<GetAllProductionOrdersQuery, Result<IReadOnlyCollection<ProductionOrderResponse>>>
{
    public async Task<Result<IReadOnlyCollection<ProductionOrderResponse>>> Handle(
        GetAllProductionOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var productionOrders = await productionOrderRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<ProductionOrderResponse>)[.. productionOrders
            .Select(x => new ProductionOrderResponse(
                x.Id,
                x.MaterialId,
                x.SiteId,
                x.PlannedProductionOrderId,
                x.QuantityToProduce.Amount,
                x.QuantityToProduce.UnitOfMeasure.Value,
                x.UnitOfMeasure.Value,
                x.ScheduledStartDate,
                x.ScheduledEndDate,
                x.OrderStatus.Name)
            )]);
    }
}