using MaterialFlow.Domain.InventoryBalances;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.InventoryBalances;

internal static class InventoryBalanceData
{
    public static InventoryBalance CreateBalance(
        Guid? id = null,
        Guid? materialId = null,
        Guid? siteId = null,
        Guid? storageLocationId = null,
        Quantity? onHand = null,
        Quantity? reserved = null,
        string? batch = null) =>
        InventoryBalance.Create(
            id ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            storageLocationId,
            onHand ?? new Quantity(100, new UnitOfMeasure("Piece")),
            reserved ?? new Quantity(0, new UnitOfMeasure("Piece")),
            batch);
}