using MaterialFlow.Domain.PlannedProductionOrders;

namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Create;

internal sealed class CreatePlannedProductionOrderCommandHandler(
    IPlannedProductionOrderRepository plannedProductionOrderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePlannedProductionOrderCommand, Guid>
{
    public async Task<Guid> Handle(
        CreatePlannedProductionOrderCommand request,
        CancellationToken cancellationToken)
    {
        var plannedProductionOrder = PlannedProductionOrder.Create(
            Guid.NewGuid(),
            request.MaterialId,
            request.SiteId,
            request.PlanningRunId,
            request.Quantity,
            new UnitOfMeasure(request.UnitOfMeasure),
            request.StartDate,
            request.EndDate,
            OrderStatus.FromValue(request.OrderStatus));

        await plannedProductionOrderRepository.AddAsync(
            plannedProductionOrder,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return plannedProductionOrder.Id;
    }
}