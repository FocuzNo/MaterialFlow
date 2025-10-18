using MaterialFlow.Domain.PlannedProductionOrders;

namespace MaterialFlow.Application.PlannedProductionOrders.Queries.GetAll;

internal sealed class GetAllPlannedProductionOrdersQueryHandler(
    IPlannedProductionOrderRepository plannedProductionOrderRepository)
    : IRequestHandler<GetAllPlannedProductionOrdersQuery, Result<IReadOnlyCollection<PlannedProductionOrderResponse>>>
{
    public async Task<Result<IReadOnlyCollection<PlannedProductionOrderResponse>>> Handle(
        GetAllPlannedProductionOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var plannedProductionOrders = await plannedProductionOrderRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<PlannedProductionOrderResponse>)[.. plannedProductionOrders
            .Select(x => new PlannedProductionOrderResponse(
                x.Id,
                x.MaterialId,
                x.SiteId,
                x.PlanningRunId,
                x.Quantity,
                x.UnitOfMeasure.Value,
                x.StartDate,
                x.EndDate,
                x.OrderStatus.Name)
            )]);
    }
}