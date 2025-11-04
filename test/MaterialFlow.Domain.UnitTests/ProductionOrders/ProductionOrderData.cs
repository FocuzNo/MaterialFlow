using MaterialFlow.Domain.ProductionOrders;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ProductionOrders;

internal static class ProductionOrderData
{
    public static ProductionOrder CreateOrder(
        Guid? id = null,
        Guid? materialId = null,
        Guid? siteId = null,
        Guid? plannedProductionOrderId = null,
        Quantity? quantityToProduce = null,
        UnitOfMeasure? unitOfMeasure = null,
        DateOnly? scheduledStartDate = null,
        DateOnly? scheduledEndDate = null,
        OrderStatus? orderStatus = null) =>
        ProductionOrder.Create(
            id ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            plannedProductionOrderId,
            quantityToProduce ?? new Quantity(100, new UnitOfMeasure("Piece")),
            unitOfMeasure ?? new UnitOfMeasure("Piece"),
            scheduledStartDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            scheduledEndDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5)),
            orderStatus ?? OrderStatus.Created);
}