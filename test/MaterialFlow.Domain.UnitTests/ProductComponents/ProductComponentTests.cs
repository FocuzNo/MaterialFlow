using MaterialFlow.Domain.ProductComponents;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ProductComponents;

public sealed class ProductComponentTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeComponent_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var productStructureId = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var unitOfMeasure = new UnitOfMeasure("Kilogram");
        var quantityPer = new Quantity(2.5m, new UnitOfMeasure("Kilogram"));
        var scrapPercentage = 5.0m;

        var component = ProductComponent.Create(
            id,
            productStructureId,
            materialId,
            unitOfMeasure,
            quantityPer,
            scrapPercentage);

        component.Id.Should().Be(id);
        component.ProductStructureId.Should().Be(productStructureId);
        component.MaterialId.Should().Be(materialId);
        component.UnitOfMeasure.Should().Be(unitOfMeasure);
        component.QuantityPer.Should().Be(quantityPer);
        component.ScrapPercentage.Should().Be(scrapPercentage);
    }

    [Fact]
    public void Create_WithoutScrapPercentage_ShouldBeNull()
    {
        var component = ProductComponentData.CreateComponent();

        component.ScrapPercentage.Should().BeNull();
    }

    [Fact]
    public void Create_WithZeroScrap_ShouldStoreZero()
    {
        var component = ProductComponentData.CreateComponent(scrapPercentage: 0m);

        component.ScrapPercentage.Should().Be(0m);
    }

    [Fact]
    public void Create_WithHighScrapRate_ShouldStoreCorrectly()
    {
        var component = ProductComponentData.CreateComponent(
            quantityPer: new Quantity(10, new UnitOfMeasure("Meter")),
            scrapPercentage: 15.75m);

        component.ScrapPercentage.Should().Be(15.75m);
    }

    [Fact]
    public void Create_WithFractionalQuantity_ShouldStoreCorrectly()
    {
        var component = ProductComponentData.CreateComponent(
            quantityPer: new Quantity(0.025m, new UnitOfMeasure("Liter")),
            scrapPercentage: 2.5m);

        component.QuantityPer.Amount.Should().Be(0.025m);
    }

    [Fact]
    public void Create_WithLargeQuantity_ShouldStoreCorrectly()
    {
        var component = ProductComponentData.CreateComponent(
            quantityPer: new Quantity(1000, new UnitOfMeasure("Piece")),
            scrapPercentage: 0.5m);

        component.QuantityPer.Amount.Should().Be(1000);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var component = ProductComponentData.CreateComponent();
        var newUnitOfMeasure = new UnitOfMeasure("Ton");
        var newQuantityPer = new Quantity(0.75m, new UnitOfMeasure("Ton"));
        var newScrapPercentage = 8.25m;

        component.Update(newUnitOfMeasure, newQuantityPer, newScrapPercentage);

        component.UnitOfMeasure.Should().Be(newUnitOfMeasure);
        component.QuantityPer.Should().Be(newQuantityPer);
        component.ScrapPercentage.Should().Be(newScrapPercentage);
    }

    [Fact]
    public void Update_ShouldNotModify_ImmutableProperties()
    {
        var component = ProductComponentData.CreateComponent();
        var originalProductStructureId = component.ProductStructureId;
        var originalMaterialId = component.MaterialId;

        component.Update(
            new UnitOfMeasure("Box"),
            new Quantity(50, new UnitOfMeasure("Box")),
            12.0m);

        component.ProductStructureId.Should().Be(originalProductStructureId);
        component.MaterialId.Should().Be(originalMaterialId);
    }

    [Fact]
    public void Update_CanSetScrapToNull()
    {
        var component = ProductComponentData.CreateComponent(scrapPercentage: 10.0m);

        component.Update(
            component.UnitOfMeasure,
            component.QuantityPer,
            null);

        component.ScrapPercentage.Should().BeNull();
    }

    [Fact]
    public void Update_CanChangeFromNullScrapToValue()
    {
        var component = ProductComponentData.CreateComponent(scrapPercentage: null);

        component.Update(
            component.UnitOfMeasure,
            component.QuantityPer,
            7.5m);

        component.ScrapPercentage.Should().Be(7.5m);
    }

    [Fact]
    public void Create_ForChemicalComponent_WithPreciseQuantity()
    {
        var component = ProductComponentData.CreateComponent(
            unitOfMeasure: new UnitOfMeasure("Milliliter"),
            quantityPer: new Quantity(125.5m, new UnitOfMeasure("Milliliter")),
            scrapPercentage: 1.2m);

        component.QuantityPer.Amount.Should().Be(125.5m);
        component.UnitOfMeasure.Value.Should().Be("Milliliter");
    }

    [Fact]
    public void Create_ForMetalComponent_WithTypicalScrap()
    {
        var component = ProductComponentData.CreateComponent(
            unitOfMeasure: new UnitOfMeasure("Kilogram"),
            quantityPer: new Quantity(3.85m, new UnitOfMeasure("Kilogram")),
            scrapPercentage: 6.0m);

        component.ScrapPercentage.Should().Be(6.0m);
        component.QuantityPer.Amount.Should().Be(3.85m);
    }

    [Fact]
    public void Create_ForElectronicComponent_WithNoScrap()
    {
        var component = ProductComponentData.CreateComponent(
            unitOfMeasure: new UnitOfMeasure("Piece"),
            quantityPer: new Quantity(4, new UnitOfMeasure("Piece")),
            scrapPercentage: null);

        component.ScrapPercentage.Should().BeNull();
        component.QuantityPer.Amount.Should().Be(4);
    }

    [Fact]
    public void Update_MultipleTimesSequentially_ShouldRetainLastValues()
    {
        var component = ProductComponentData.CreateComponent();

        component.Update(
            new UnitOfMeasure("Gram"),
            new Quantity(100, new UnitOfMeasure("Gram")),
            5.0m);

        component.Update(
            new UnitOfMeasure("Kilogram"),
            new Quantity(0.1m, new UnitOfMeasure("Kilogram")),
            4.5m);

        var finalUnitOfMeasure = new UnitOfMeasure("Ton");
        var finalQuantity = new Quantity(0.0001m, new UnitOfMeasure("Ton"));
        var finalScrap = 4.0m;

        component.Update(finalUnitOfMeasure, finalQuantity, finalScrap);

        component.UnitOfMeasure.Should().Be(finalUnitOfMeasure);
        component.QuantityPer.Should().Be(finalQuantity);
        component.ScrapPercentage.Should().Be(finalScrap);
    }
}