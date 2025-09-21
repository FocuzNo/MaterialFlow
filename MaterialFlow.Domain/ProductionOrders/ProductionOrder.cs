using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.PlannedProductionOrders;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.ProductionOrders;

public sealed class ProductionOrder : Entity
{
    private ProductionOrder() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public Guid? ConvertedFromPlannedOrderId { get; private set; }
    public PlannedProductionOrder? ConvertedFromPlannedOrder { get; private set; }

    public Quantity QuantityToProduce { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public DateOnly ScheduledStartDate { get; private set; }

    public DateOnly ScheduledEndDate { get; private set; }

    public OrderStatus OrderStatus { get; private set; }

    public static ProductionOrder Create(
        Guid id,
        Guid materialId,
        Guid siteId,
        Guid? convertedFromPlannedOrderId,
        Quantity quantityToProduce,
        UnitOfMeasure unitOfMeasure,
        DateOnly scheduledStartDate,
        DateOnly scheduledEndDate,
        OrderStatus orderStatus)
        => new()
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            ConvertedFromPlannedOrderId = convertedFromPlannedOrderId,
            QuantityToProduce = quantityToProduce,
            UnitOfMeasure = unitOfMeasure,
            ScheduledStartDate = scheduledStartDate,
            ScheduledEndDate = scheduledEndDate,
            OrderStatus = orderStatus
        };

    public void Update(
        Quantity quantityToProduce,
        DateOnly scheduledStartDate,
        DateOnly scheduledEndDate,
        OrderStatus orderStatus)
    {
        QuantityToProduce = quantityToProduce;
        ScheduledStartDate = scheduledStartDate;
        ScheduledEndDate = scheduledEndDate;
        OrderStatus = orderStatus;
    }
}
