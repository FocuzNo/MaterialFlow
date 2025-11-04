using MaterialFlow.Domain.InventoryBalances;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.UnitTests.Infrastructure;

namespace MaterialFlow.Domain.UnitTests.InventoryBalances;

public sealed class InventoryBalanceTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeBalance_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var storageLocationId = Guid.NewGuid();
        var onHand = new Quantity(5000, new UnitOfMeasure("Piece"));
        var reserved = new Quantity(1250, new UnitOfMeasure("Piece"));
        var batch = "BATCH-2025-Q3-7892";

        var balance = InventoryBalance.Create(
            id,
            materialId,
            siteId,
            storageLocationId,
            onHand,
            reserved,
            batch);

        balance.Id.Should().Be(id);
        balance.MaterialId.Should().Be(materialId);
        balance.SiteId.Should().Be(siteId);
        balance.StorageLocationId.Should().Be(storageLocationId);
        balance.OnHand.Should().Be(onHand);
        balance.Reserved.Should().Be(reserved);
        balance.Batch.Should().Be(batch);
    }

    [Fact]
    public void Create_WithoutStorageLocation_ShouldBeNull()
    {
        var balance = InventoryBalanceData.CreateBalance();

        balance.StorageLocationId.Should().BeNull();
        balance.StorageLocation.Should().BeNull();
    }

    [Fact]
    public void Create_WithoutBatch_ShouldBeNull()
    {
        var balance = InventoryBalanceData.CreateBalance();

        balance.Batch.Should().BeNull();
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var balance = InventoryBalanceData.CreateBalance();
        var newOnHand = new Quantity(8750, new UnitOfMeasure("Kilogram"));
        var newReserved = new Quantity(2100, new UnitOfMeasure("Kilogram"));
        var newBatch = "LOT-2026-A-3456";

        balance.Update(newOnHand, newReserved, newBatch);

        balance.OnHand.Should().Be(newOnHand);
        balance.Reserved.Should().Be(newReserved);
        balance.Batch.Should().Be(newBatch);
    }

    [Fact]
    public void Update_ShouldNotModify_OtherProperties()
    {
        var balance = InventoryBalanceData.CreateBalance();
        var originalMaterialId = balance.MaterialId;
        var originalSiteId = balance.SiteId;
        var originalStorageLocationId = balance.StorageLocationId;

        balance.Update(
            new Quantity(12000, new UnitOfMeasure("Ton")),
            new Quantity(3500, new UnitOfMeasure("Ton")),
            "BATCH-X9Y8Z7");

        balance.MaterialId.Should().Be(originalMaterialId);
        balance.SiteId.Should().Be(originalSiteId);
        balance.StorageLocationId.Should().Be(originalStorageLocationId);
    }

    [Fact]
    public void Update_CanClearBatch()
    {
        var balance = InventoryBalanceData.CreateBalance(batch: "OLD-BATCH-9999");

        balance.Update(
            new Quantity(500, new UnitOfMeasure("Liter")),
            new Quantity(0, new UnitOfMeasure("Liter")),
            null);

        balance.Batch.Should().BeNull();
    }
}