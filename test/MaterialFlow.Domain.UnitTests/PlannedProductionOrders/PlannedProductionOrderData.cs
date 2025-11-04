using MaterialFlow.Domain.PlannedProductionOrders;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.PlannedProductionOrders;

internal static class PlannedProductionOrderData
{
    public static PlannedProductionOrder CreateOrder(
        Guid? id = null,
        Guid? materialId = null,
        Guid? siteId = null,
        Guid? planningRunId = null,
        decimal? quantity = null,
        UnitOfMeasure? unitOfMeasure = null,
        DateOnly? startDate = null,
        DateOnly? endDate = null,
        OrderStatus? orderStatus = null) =>
        PlannedProductionOrder.Create(
            id ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            planningRunId,
            quantity ?? 100,
            unitOfMeasure ?? new UnitOfMeasure("Piece"),
            startDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            endDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddDays(7)),
            orderStatus ?? OrderStatus.Created);
}