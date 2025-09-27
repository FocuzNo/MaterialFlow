using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.PlanningRuns;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;
using MaterialFlow.Domain.PlannedProductionOrders.Events;

namespace MaterialFlow.Domain.PlannedProductionOrders;

public sealed class PlannedProductionOrder : Entity
{
    private PlannedProductionOrder() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public Guid? PlanningRunId { get; private set; }
    public PlanningRun? PlanningRun { get; private set; }

    public decimal Quantity { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public DateOnly StartDate { get; private set; }

    public DateOnly EndDate { get; private set; }

    public OrderStatus OrderStatus { get; private set; }

    public static PlannedProductionOrder Create(
        Guid id,
        Guid materialId,
        Guid siteId,
        Guid? planningRunId,
        decimal quantity,
        UnitOfMeasure unitOfMeasure,
        DateOnly startDate,
        DateOnly endDate,
        OrderStatus orderStatus)
    {
        var order = new PlannedProductionOrder
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            PlanningRunId = planningRunId,
            Quantity = quantity,
            UnitOfMeasure = unitOfMeasure,
            StartDate = startDate,
            EndDate = endDate,
            OrderStatus = orderStatus
        };

        order.RaiseDomainEvent(new PlannedProductionOrderCreatedDomainEvent(order.Id));

        return order;
    }

    public void Update(
        decimal quantity,
        DateOnly startDate,
        DateOnly endDate,
        OrderStatus orderStatus)
    {
        Quantity = quantity;
        StartDate = startDate;
        EndDate = endDate;
        OrderStatus = orderStatus;

        RaiseDomainEvent(new PlannedProductionOrderApprovedDomainEvent(Id));
    }

    public void Cancel()
    {
        if (OrderStatus == OrderStatus.Cancelled)
        {
            return;
        }

        OrderStatus = OrderStatus.Cancelled;

        RaiseDomainEvent(new PlannedProductionOrderCancelledDomainEvent(Id));
    }
}
