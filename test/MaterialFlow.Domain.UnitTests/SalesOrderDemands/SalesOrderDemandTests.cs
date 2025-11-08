using MaterialFlow.Domain.SalesOrderDemands;
using MaterialFlow.Domain.SalesOrderDemands.Events;
using MaterialFlow.Domain.SalesOrderDemands.ValueObjects;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.SalesOrderDemands;

public sealed class SalesOrderDemandTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeDemand_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var requirementDate = new DateOnly(2025, 12, 20);
        var quantity = new Quantity(2500, new UnitOfMeasure("Piece"));
        var unitOfMeasure = new UnitOfMeasure("Piece");
        var sourceDocument = new SourceDocument("SalesOrder", "SO-2025-1234", "100");

        var demand = SalesOrderDemand.Create(
            id,
            materialId,
            siteId,
            requirementDate,
            quantity,
            unitOfMeasure,
            sourceDocument);

        demand.Id.Should().Be(id);
        demand.MaterialId.Should().Be(materialId);
        demand.SiteId.Should().Be(siteId);
        demand.RequirementDate.Should().Be(requirementDate);
        demand.Quantity.Should().Be(quantity);
        demand.UnitOfMeasure.Should().Be(unitOfMeasure);
        demand.SourceDocument.Should().Be(sourceDocument);
    }

    [Fact]
    public void Create_ShouldRaise_SalesOrderDemandCreatedDomainEvent()
    {
        var demand = SalesOrderDemandData.CreateDemand();

        AssertDomainEventWasPublished<SalesOrderDemandCreatedDomainEvent>(demand);
    }

    [Fact]
    public void Create_ForUrgentOrder_ShouldStoreCorrectly()
    {
        var urgentDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2));

        var demand = SalesOrderDemandData.CreateDemand(
            requirementDate: urgentDate,
            quantity: new Quantity(100, new UnitOfMeasure("Box")),
            unitOfMeasure: new UnitOfMeasure("Box"),
            sourceDocument: new SourceDocument("UrgentOrder", "SO-URGENT-9876", "10"));

        demand.RequirementDate.Should().Be(urgentDate);
        demand.SourceDocument.Number.Should().Contain("URGENT");
    }

    [Fact]
    public void Create_ForLargeOrder_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(50000, new UnitOfMeasure("Kilogram")),
            unitOfMeasure: new UnitOfMeasure("Kilogram"),
            requirementDate: new DateOnly(2026, 2, 15),
            sourceDocument: new SourceDocument("BulkOrder", "SO-BULK-2026-5555", "20"));

        demand.Quantity.Amount.Should().Be(50000);
        demand.SourceDocument.Type.Should().Be("BulkOrder");
    }

    [Fact]
    public void Create_ForMultiLineSalesOrder_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            sourceDocument: new SourceDocument("SalesOrder", "SO-2025-7890", "50"));

        demand.SourceDocument.ItemNumber.Should().Be("50");
    }

    [Fact]
    public void Create_WithDifferentItemNumbers_ShouldBeDifferent()
    {
        var sourceDoc1 = new SourceDocument("SalesOrder", "SO-2025-1111", "10");
        var sourceDoc2 = new SourceDocument("SalesOrder", "SO-2025-1111", "20");

        var demand1 = SalesOrderDemandData.CreateDemand(sourceDocument: sourceDoc1);
        var demand2 = SalesOrderDemandData.CreateDemand(sourceDocument: sourceDoc2);

        demand1.SourceDocument.Should().NotBe(demand2.SourceDocument);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var demand = SalesOrderDemandData.CreateDemand();
        var newRequirementDate = new DateOnly(2026, 3, 30);
        var newQuantity = new Quantity(7500, new UnitOfMeasure("Liter"));
        var newUnitOfMeasure = new UnitOfMeasure("Liter");

        demand.Update(newRequirementDate, newQuantity, newUnitOfMeasure);

        demand.RequirementDate.Should().Be(newRequirementDate);
        demand.Quantity.Should().Be(newQuantity);
        demand.UnitOfMeasure.Should().Be(newUnitOfMeasure);
    }

    [Fact]
    public void Update_ShouldRaise_SalesOrderDemandUpdatedDomainEvent()
    {
        var demand = SalesOrderDemandData.CreateDemand();
        demand.ClearDomainEvents();

        demand.Update(
            new DateOnly(2026, 5, 10),
            new Quantity(3000, new UnitOfMeasure("Ton")),
            new UnitOfMeasure("Ton"));

        AssertDomainEventWasPublished<SalesOrderDemandUpdatedDomainEvent>(demand);
    }

    [Fact]
    public void Update_ShouldNotModify_ImmutableProperties()
    {
        var demand = SalesOrderDemandData.CreateDemand();
        var originalMaterialId = demand.MaterialId;
        var originalSiteId = demand.SiteId;
        var originalSourceDocument = demand.SourceDocument;

        demand.Update(
            new DateOnly(2026, 6, 20),
            new Quantity(1500, new UnitOfMeasure("Piece")),
            new UnitOfMeasure("Piece"));

        demand.MaterialId.Should().Be(originalMaterialId);
        demand.SiteId.Should().Be(originalSiteId);
        demand.SourceDocument.Should().Be(originalSourceDocument);
    }

    [Fact]
    public void Update_WithIncreasedQuantity_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(1000, new UnitOfMeasure("Piece")));

        demand.Update(
            demand.RequirementDate,
            new Quantity(2500, new UnitOfMeasure("Piece")),
            demand.UnitOfMeasure);

        demand.Quantity.Amount.Should().Be(2500);
    }

    [Fact]
    public void Update_WithDecreasedQuantity_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(5000, new UnitOfMeasure("Kilogram")));

        demand.Update(
            demand.RequirementDate,
            new Quantity(3200, new UnitOfMeasure("Kilogram")),
            demand.UnitOfMeasure);

        demand.Quantity.Amount.Should().Be(3200);
    }

    [Fact]
    public void Create_ForExportOrder_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(15000, new UnitOfMeasure("Piece")),
            requirementDate: new DateOnly(2026, 4, 1),
            sourceDocument: new SourceDocument("ExportOrder", "EXP-2026-1001", "30"));

        demand.SourceDocument.Type.Should().Be("ExportOrder");
    }

    [Fact]
    public void Create_ForDomesticOrder_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(500, new UnitOfMeasure("Box")),
            requirementDate: new DateOnly(2025, 11, 30),
            sourceDocument: new SourceDocument("DomesticOrder", "DOM-2025-3456", "15"));

        demand.SourceDocument.Type.Should().Be("DomesticOrder");
    }

    [Fact]
    public void Create_ForContractOrder_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(100000, new UnitOfMeasure("Liter")),
            requirementDate: new DateOnly(2026, 6, 30),
            sourceDocument: new SourceDocument("ContractOrder", "CONTRACT-2026-ANNUAL", "5"));

        demand.Quantity.Amount.Should().Be(100000);
        demand.SourceDocument.Type.Should().Be("ContractOrder");
    }

    [Fact]
    public void Update_CanChangeUnitOfMeasure()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(1000, new UnitOfMeasure("Kilogram")),
            unitOfMeasure: new UnitOfMeasure("Kilogram"));

        demand.Update(
            demand.RequirementDate,
            new Quantity(1, new UnitOfMeasure("Ton")),
            new UnitOfMeasure("Ton"));

        demand.UnitOfMeasure.Value.Should().Be("Ton");
        demand.Quantity.Amount.Should().Be(1);
    }

    [Fact]
    public void Create_ForPromotionalOrder_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(10000, new UnitOfMeasure("Piece")),
            requirementDate: new DateOnly(2025, 12, 10),
            sourceDocument: new SourceDocument("PromotionalOrder", "PROMO-BLACK-FRIDAY-2025", "100"));

        demand.SourceDocument.Type.Should().Be("PromotionalOrder");
    }

    [Fact]
    public void Create_WithNumericItemNumber_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            sourceDocument: new SourceDocument("SalesOrder", "SO-12345", "250"));

        demand.SourceDocument.ItemNumber.Should().Be("250");
    }

    [Fact]
    public void Create_ForCashOrder_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(50, new UnitOfMeasure("Piece")),
            requirementDate: new DateOnly(2025, 11, 25),
            sourceDocument: new SourceDocument("CashSale", "CASH-2025-8888", "1"));

        demand.SourceDocument.Type.Should().Be("CashSale");
    }

    [Fact]
    public void Create_ForFrameworkAgreement_ShouldStoreCorrectly()
    {
        var demand = SalesOrderDemandData.CreateDemand(
            quantity: new Quantity(25000, new UnitOfMeasure("Piece")),
            requirementDate: new DateOnly(2026, 9, 15),
            sourceDocument: new SourceDocument("FrameworkAgreement", "FA-2026-ANNUAL-CORP", "12"));

        demand.SourceDocument.Type.Should().Be("FrameworkAgreement");
        demand.SourceDocument.Number.Should().Contain("ANNUAL");
    }

    [Fact]
    public void Update_MultipleTimesSequentially_ShouldRetainLastValues()
    {
        var demand = SalesOrderDemandData.CreateDemand();

        demand.Update(
            new DateOnly(2026, 1, 10),
            new Quantity(500, new UnitOfMeasure("Piece")),
            new UnitOfMeasure("Piece"));

        demand.Update(
            new DateOnly(2026, 2, 15),
            new Quantity(750, new UnitOfMeasure("Piece")),
            new UnitOfMeasure("Piece"));

        var finalDate = new DateOnly(2026, 3, 20);
        var finalQuantity = new Quantity(1000, new UnitOfMeasure("Piece"));

        demand.Update(finalDate, finalQuantity, demand.UnitOfMeasure);

        demand.RequirementDate.Should().Be(finalDate);
        demand.Quantity.Should().Be(finalQuantity);
    }
}