using MaterialFlow.Domain.PlannedProductionOrders;

namespace MaterialFlow.Application.PlannedProductionOrders.Queries.GetById;

internal sealed class GetPlannedProductionOrderByIdQueryHandler(
    IPlannedProductionOrderRepository plannedProductionOrderRepository)
    : IRequestHandler<GetPlannedProductionOrderByIdQuery, Result<PlannedProductionOrderResponse>>
{
    public async Task<Result<PlannedProductionOrderResponse>> Handle(
        GetPlannedProductionOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var plannedProductionOrder = await plannedProductionOrderRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (plannedProductionOrder is null)
        {
            return Result.Failure<PlannedProductionOrderResponse>(PlannedProductionOrderErrors.NotFound);
        }

        var response = new PlannedProductionOrderResponse(
            plannedProductionOrder.Id,
            plannedProductionOrder.MaterialId,
            plannedProductionOrder.SiteId,
            plannedProductionOrder.PlanningRunId,
            plannedProductionOrder.Quantity,
            plannedProductionOrder.UnitOfMeasure.Value,
            plannedProductionOrder.StartDate,
            plannedProductionOrder.EndDate,
            plannedProductionOrder.OrderStatus.Name);

        return Result.Success(response);
    }
}