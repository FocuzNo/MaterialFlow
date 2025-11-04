using MaterialFlow.Domain.ComponentReservations;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ComponentReservations;

internal static class ComponentReservationData
{
    private static readonly Quantity DefaultQuantity = new(100, new UnitOfMeasure("Piece"));

    public static ComponentReservation CreateReservation(
        Guid? id = null,
        string? sourceOrderType = null,
        Guid? sourceOrderId = null,
        Guid? materialId = null,
        Guid? siteId = null,
        DateOnly? requirementDate = null,
        Quantity? quantity = null,
        ReservationStatus? status = null) =>
        ComponentReservation.Create(
            id ?? Guid.NewGuid(),
            sourceOrderType ?? "ProductionOrder",
            sourceOrderId ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            requirementDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            quantity ?? DefaultQuantity,
            status);

    public static Quantity CreateQuantity(
        decimal amount = 100,
        string unitOfMeasure = "Piece") =>
        new(amount, new UnitOfMeasure(unitOfMeasure));
}