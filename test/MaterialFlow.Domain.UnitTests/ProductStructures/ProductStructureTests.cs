using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.ProductStructures;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.UnitTests.Infrastructure;

namespace MaterialFlow.Domain.UnitTests.ProductStructures;

public sealed class ProductStructureTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeStructure_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var usage = BillOfMaterialsUsage.Production;
        var alternativeNumber = "ALT-001";
        var validFromDate = new DateOnly(2025, 1, 1);
        var validToDate = new DateOnly(2025, 12, 31);
        var orderStatus = OrderStatus.Created;

        var structure = ProductStructure.Create(
            id,
            materialId,
            siteId,
            usage,
            alternativeNumber,
            validFromDate,
            validToDate,
            orderStatus);

        structure.Id.Should().Be(id);
        structure.MaterialId.Should().Be(materialId);
        structure.SiteId.Should().Be(siteId);
        structure.Usage.Should().Be(usage);
        structure.AlternativeNumber.Should().Be(alternativeNumber);
        structure.ValidFromDate.Should().Be(validFromDate);
        structure.ValidToDate.Should().Be(validToDate);
        structure.OrderStatus.Should().Be(orderStatus);
        structure.Components.Should().BeEmpty();
    }

    [Fact]
    public void Create_WithoutOptionalFields_ShouldBeNull()
    {
        var structure = ProductStructureData.CreateStructure();

        structure.SiteId.Should().BeNull();
        structure.Site.Should().BeNull();
        structure.AlternativeNumber.Should().BeNull();
        structure.ValidToDate.Should().BeNull();
    }

    [Fact]
    public void Create_WithIndefiniteValidity_ShouldHaveNullEndDate()
    {
        var structure = ProductStructureData.CreateStructure(
            validFromDate: new DateOnly(2025, 1, 1),
            validToDate: null);

        structure.ValidFromDate.Should().Be(new DateOnly(2025, 1, 1));
        structure.ValidToDate.Should().BeNull();
    }

    [Fact]
    public void AddComponent_ShouldAddToCollection()
    {
        var structure = ProductStructureData.CreateStructure();
        var componentMaterialId = Guid.NewGuid();
        var unitOfMeasure = new UnitOfMeasure("Kilogram");
        var quantityPer = new Quantity(2.5m, new UnitOfMeasure("Kilogram"));
        var scrapPercentage = 5.0m;

        var component = structure.AddComponent(
            componentMaterialId,
            unitOfMeasure,
            quantityPer,
            scrapPercentage);

        structure.Components.Should().ContainSingle();
        structure.Components.Should().Contain(component);
        component.ProductStructureId.Should().Be(structure.Id);
        component.MaterialId.Should().Be(componentMaterialId);
    }

    [Fact]
    public void AddComponent_ShouldGenerateComponentId()
    {
        var structure = ProductStructureData.CreateStructure();

        var component = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Piece"),
            new Quantity(4, new UnitOfMeasure("Piece")),
            null);

        component.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void AddComponent_MultipleComponents_ShouldAddAll()
    {
        var structure = ProductStructureData.CreateStructure();

        var component1 = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Piece"),
            new Quantity(1, new UnitOfMeasure("Piece")),
            null);

        var component2 = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Liter"),
            new Quantity(0.5m, new UnitOfMeasure("Liter")),
            2.0m);

        var component3 = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Meter"),
            new Quantity(3.2m, new UnitOfMeasure("Meter")),
            8.5m);

        structure.Components.Should().HaveCount(3);
        structure.Components.Should().Contain(new[] { component1, component2, component3 });
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var structure = ProductStructureData.CreateStructure();
        var newMaterialId = Guid.NewGuid();
        var newSiteId = Guid.NewGuid();
        var newUsage = BillOfMaterialsUsage.Production;
        var newAlternativeNumber = "ALT-REVISED-002";
        var newValidFromDate = new DateOnly(2026, 1, 1);
        var newValidToDate = new DateOnly(2026, 6, 30);
        var newOrderStatus = OrderStatus.Open;

        structure.Update(
            newMaterialId,
            newSiteId,
            newUsage,
            newAlternativeNumber,
            newValidFromDate,
            newValidToDate,
            newOrderStatus);

        structure.MaterialId.Should().Be(newMaterialId);
        structure.SiteId.Should().Be(newSiteId);
        structure.Usage.Should().Be(newUsage);
        structure.AlternativeNumber.Should().Be(newAlternativeNumber);
        structure.ValidFromDate.Should().Be(newValidFromDate);
        structure.ValidToDate.Should().Be(newValidToDate);
        structure.OrderStatus.Should().Be(newOrderStatus);
    }

    [Fact]
    public void Update_CanSetOptionalFieldsToNull()
    {
        var structure = ProductStructureData.CreateStructure(
            siteId: Guid.NewGuid(),
            alternativeNumber: "ALT-001",
            validToDate: new DateOnly(2025, 12, 31));

        structure.Update(
            structure.MaterialId,
            null,
            structure.Usage,
            null,
            structure.ValidFromDate,
            null,
            structure.OrderStatus);

        structure.SiteId.Should().BeNull();
        structure.AlternativeNumber.Should().BeNull();
        structure.ValidToDate.Should().BeNull();
    }

    [Fact]
    public void RemoveComponent_ShouldRemoveFromCollection()
    {
        var structure = ProductStructureData.CreateStructure();
        var component = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Piece"),
            new Quantity(2, new UnitOfMeasure("Piece")),
            null);

        structure.RemoveComponent(component.Id);

        structure.Components.Should().BeEmpty();
    }

    [Fact]
    public void RemoveComponent_WithNonExistentId_ShouldNotThrow()
    {
        var structure = ProductStructureData.CreateStructure();
        var nonExistentId = Guid.NewGuid();

        var action = () => structure.RemoveComponent(nonExistentId);

        action.Should().NotThrow();
        structure.Components.Should().BeEmpty();
    }

    [Fact]
    public void RemoveComponent_ShouldRemoveOnlySpecifiedComponent()
    {
        var structure = ProductStructureData.CreateStructure();
        var component1 = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Piece"),
            new Quantity(1, new UnitOfMeasure("Piece")),
            null);

        var component2 = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Kilogram"),
            new Quantity(5, new UnitOfMeasure("Kilogram")),
            3.0m);

        structure.RemoveComponent(component1.Id);

        structure.Components.Should().ContainSingle();
        structure.Components.Should().Contain(component2);
        structure.Components.Should().NotContain(component1);
    }

    [Fact]
    public void Create_ForProductionBOM_WithMultipleLevels()
    {
        var structure = ProductStructureData.CreateStructure(
            usage: BillOfMaterialsUsage.Production,
            validFromDate: new DateOnly(2025, 1, 1));

        structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Piece"),
            new Quantity(4, new UnitOfMeasure("Piece")),
            1.0m);

        structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Meter"),
            new Quantity(2.5m, new UnitOfMeasure("Meter")),
            5.0m);

        structure.Components.Should().HaveCount(2);
        structure.Usage.Should().Be(BillOfMaterialsUsage.Production);
    }

    [Fact]
    public void Create_ForCostingBOM_WithAlternative()
    {
        var structure = ProductStructureData.CreateStructure(
            usage: BillOfMaterialsUsage.Sales,
            alternativeNumber: "COST-ALT-A",
            validFromDate: new DateOnly(2025, 6, 1),
            validToDate: new DateOnly(2025, 12, 31));

        structure.Usage.Should().Be(BillOfMaterialsUsage.Sales);
        structure.AlternativeNumber.Should().Be("COST-ALT-A");
    }

    [Fact]
    public void Update_FromOpenToClosed_ShouldUpdateStatus()
    {
        var structure = ProductStructureData.CreateStructure(orderStatus: OrderStatus.Open);

        structure.Update(
            structure.MaterialId,
            structure.SiteId,
            structure.Usage,
            structure.AlternativeNumber,
            structure.ValidFromDate,
            structure.ValidToDate,
            OrderStatus.Closed);

        structure.OrderStatus.Should().Be(OrderStatus.Closed);
    }

    [Fact]
    public void Create_WithExpiredValidity_ShouldStoreCorrectly()
    {
        var structure = ProductStructureData.CreateStructure(
            validFromDate: new DateOnly(2024, 1, 1),
            validToDate: new DateOnly(2024, 12, 31));

        structure.ValidFromDate.Should().Be(new DateOnly(2024, 1, 1));
        structure.ValidToDate.Should().Be(new DateOnly(2024, 12, 31));
    }

    [Fact]
    public void AddComponent_ThenRemoveAll_ShouldBeEmpty()
    {
        var structure = ProductStructureData.CreateStructure();
        var comp1 = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Piece"),
            new Quantity(1, new UnitOfMeasure("Piece")),
            null);

        var comp2 = structure.AddComponent(
            Guid.NewGuid(),
            new UnitOfMeasure("Piece"),
            new Quantity(2, new UnitOfMeasure("Piece")),
            null);

        structure.RemoveComponent(comp1.Id);
        structure.RemoveComponent(comp2.Id);

        structure.Components.Should().BeEmpty();
    }
}