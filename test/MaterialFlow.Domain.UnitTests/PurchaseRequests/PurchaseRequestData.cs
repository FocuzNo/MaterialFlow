using MaterialFlow.Domain.PurchaseRequests;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.PurchaseRequests;

internal static class PurchaseRequestData
{
    public static PurchaseRequest CreateRequest(
        Guid? id = null,
        Guid? materialId = null,
        Guid? siteId = null,
        Guid? planningRunId = null,
        Quantity? quantity = null,
        UnitOfMeasure? unitOfMeasure = null,
        DateOnly? requestedDeliveryDate = null,
        string? purchasingGroup = null,
        OrderStatus? orderStatus = null) =>
        PurchaseRequest.Create(
            id ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            planningRunId,
            quantity ?? new Quantity(100, new UnitOfMeasure("Piece")),
            unitOfMeasure ?? new UnitOfMeasure("Piece"),
            requestedDeliveryDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddDays(14)),
            purchasingGroup,
            orderStatus ?? OrderStatus.Created);
}