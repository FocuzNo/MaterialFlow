using MaterialFlow.Domain.PurchaseRequests;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.UnitTests.Infrastructure;

namespace MaterialFlow.Domain.UnitTests.PurchaseRequests;

public sealed class PurchaseRequestTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeRequest_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var planningRunId = Guid.NewGuid();
        var quantity = new Quantity(5000, new UnitOfMeasure("Kilogram"));
        var unitOfMeasure = new UnitOfMeasure("Kilogram");
        var requestedDeliveryDate = new DateOnly(2025, 12, 15);
        var purchasingGroup = "RAW-MATERIALS";
        var orderStatus = OrderStatus.Created;

        var request = PurchaseRequest.Create(
            id,
            materialId,
            siteId,
            planningRunId,
            quantity,
            unitOfMeasure,
            requestedDeliveryDate,
            purchasingGroup,
            orderStatus);

        request.Id.Should().Be(id);
        request.MaterialId.Should().Be(materialId);
        request.SiteId.Should().Be(siteId);
        request.PlanningRunId.Should().Be(planningRunId);
        request.Quantity.Should().Be(quantity);
        request.UnitOfMeasure.Should().Be(unitOfMeasure);
        request.RequestedDeliveryDate.Should().Be(requestedDeliveryDate);
        request.PurchasingGroup.Should().Be(purchasingGroup);
        request.OrderStatus.Should().Be(orderStatus);
    }

    [Fact]
    public void Create_WithoutOptionalFields_ShouldBeNull()
    {
        var request = PurchaseRequestData.CreateRequest();

        request.PlanningRunId.Should().BeNull();
        request.PlanningRun.Should().BeNull();
        request.PurchasingGroup.Should().BeNull();
    }

    [Fact]
    public void Create_ForUrgentDelivery_ShouldStoreCorrectly()
    {
        var urgentDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(3));

        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(100, new UnitOfMeasure("Piece")),
            requestedDeliveryDate: urgentDate,
            purchasingGroup: "EXPEDITED",
            orderStatus: OrderStatus.Open);

        request.RequestedDeliveryDate.Should().Be(urgentDate);
        request.PurchasingGroup.Should().Be("EXPEDITED");
    }

    [Fact]
    public void Create_ForBulkOrder_ShouldStoreCorrectly()
    {
        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(50000, new UnitOfMeasure("Liter")),
            unitOfMeasure: new UnitOfMeasure("Liter"),
            requestedDeliveryDate: new DateOnly(2026, 3, 1),
            purchasingGroup: "CHEMICALS-BULK");

        request.Quantity.Amount.Should().Be(50000);
        request.PurchasingGroup.Should().Be("CHEMICALS-BULK");
    }

    [Fact]
    public void Create_ForSmallOrder_ShouldStoreCorrectly()
    {
        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(10, new UnitOfMeasure("Box")),
            unitOfMeasure: new UnitOfMeasure("Box"),
            requestedDeliveryDate: new DateOnly(2025, 11, 20),
            purchasingGroup: "OFFICE-SUPPLIES");

        request.Quantity.Amount.Should().Be(10);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var request = PurchaseRequestData.CreateRequest();
        var newQuantity = new Quantity(7500, new UnitOfMeasure("Ton"));
        var newDeliveryDate = new DateOnly(2026, 2, 28);
        var newPurchasingGroup = "METALS";
        var newOrderStatus = OrderStatus.Open;

        request.Update(newQuantity, newDeliveryDate, newPurchasingGroup, newOrderStatus);

        request.Quantity.Should().Be(newQuantity);
        request.RequestedDeliveryDate.Should().Be(newDeliveryDate);
        request.PurchasingGroup.Should().Be(newPurchasingGroup);
        request.OrderStatus.Should().Be(newOrderStatus);
    }

    [Fact]
    public void Update_ShouldNotModify_ImmutableProperties()
    {
        var request = PurchaseRequestData.CreateRequest();
        var originalMaterialId = request.MaterialId;
        var originalSiteId = request.SiteId;
        var originalPlanningRunId = request.PlanningRunId;
        var originalUnitOfMeasure = request.UnitOfMeasure;

        request.Update(
            new Quantity(2000, new UnitOfMeasure("Piece")),
            new DateOnly(2026, 4, 15),
            "NEW-GROUP",
            OrderStatus.Closed);

        request.MaterialId.Should().Be(originalMaterialId);
        request.SiteId.Should().Be(originalSiteId);
        request.PlanningRunId.Should().Be(originalPlanningRunId);
        request.UnitOfMeasure.Should().Be(originalUnitOfMeasure);
    }

    [Fact]
    public void Update_CanSetPurchasingGroupToNull()
    {
        var request = PurchaseRequestData.CreateRequest(purchasingGroup: "ELECTRONICS");

        request.Update(
            request.Quantity,
            request.RequestedDeliveryDate,
            null,
            request.OrderStatus);

        request.PurchasingGroup.Should().BeNull();
    }

    [Fact]
    public void Update_CanChangePurchasingGroupFromNull()
    {
        var request = PurchaseRequestData.CreateRequest(purchasingGroup: null);

        request.Update(
            request.Quantity,
            request.RequestedDeliveryDate,
            "MACHINERY",
            request.OrderStatus);

        request.PurchasingGroup.Should().Be("MACHINERY");
    }

    [Fact]
    public void Create_WithElectronicsGroup_ShouldStoreCorrectly()
    {
        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(250, new UnitOfMeasure("Piece")),
            requestedDeliveryDate: new DateOnly(2025, 12, 5),
            purchasingGroup: "ELECTRONICS");

        request.PurchasingGroup.Should().Be("ELECTRONICS");
    }

    [Fact]
    public void Create_WithPackagingMaterials_ShouldStoreCorrectly()
    {
        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(10000, new UnitOfMeasure("Piece")),
            unitOfMeasure: new UnitOfMeasure("Piece"),
            requestedDeliveryDate: new DateOnly(2026, 1, 10),
            purchasingGroup: "PACKAGING");

        request.PurchasingGroup.Should().Be("PACKAGING");
        request.Quantity.Amount.Should().Be(10000);
    }

    [Fact]
    public void Create_ForMROSpares_ShouldStoreCorrectly()
    {
        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(5, new UnitOfMeasure("Piece")),
            requestedDeliveryDate: new DateOnly(2025, 11, 25),
            purchasingGroup: "MRO-SPARES",
            orderStatus: OrderStatus.Open);

        request.PurchasingGroup.Should().Be("MRO-SPARES");
    }

    [Fact]
    public void Update_FromCreatedToOpen_ShouldUpdateStatus()
    {
        var request = PurchaseRequestData.CreateRequest(orderStatus: OrderStatus.Created);

        request.Update(
            request.Quantity,
            request.RequestedDeliveryDate,
            request.PurchasingGroup,
            OrderStatus.Open);

        request.OrderStatus.Should().Be(OrderStatus.Open);
    }

    [Fact]
    public void Update_FromOpenToClosed_ShouldUpdateStatus()
    {
        var request = PurchaseRequestData.CreateRequest(orderStatus: OrderStatus.Open);

        request.Update(
            request.Quantity,
            request.RequestedDeliveryDate,
            request.PurchasingGroup,
            OrderStatus.Closed);

        request.OrderStatus.Should().Be(OrderStatus.Closed);
    }

    [Fact]
    public void Update_WithIncreasedQuantity_ShouldStoreCorrectly()
    {
        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(1000, new UnitOfMeasure("Kilogram")));

        request.Update(
            new Quantity(3500, new UnitOfMeasure("Kilogram")),
            request.RequestedDeliveryDate,
            "REVISED-ORDER",
            OrderStatus.Open);

        request.Quantity.Amount.Should().Be(3500);
        request.PurchasingGroup.Should().Be("REVISED-ORDER");
    }

    [Fact]
    public void Update_WithRescheduledDate_ShouldStoreCorrectly()
    {
        var originalDate = new DateOnly(2025, 12, 1);
        var request = PurchaseRequestData.CreateRequest(requestedDeliveryDate: originalDate);
        var rescheduledDate = new DateOnly(2026, 1, 15);

        request.Update(
            request.Quantity,
            rescheduledDate,
            request.PurchasingGroup,
            request.OrderStatus);

        request.RequestedDeliveryDate.Should().Be(rescheduledDate);
        request.RequestedDeliveryDate.Should().NotBe(originalDate);
    }

    [Fact]
    public void Create_WithPlanningRun_ShouldLinkCorrectly()
    {
        var planningRunId = Guid.NewGuid();

        var request = PurchaseRequestData.CreateRequest(planningRunId: planningRunId);

        request.PlanningRunId.Should().Be(planningRunId);
    }

    [Fact]
    public void Create_ForConstructionMaterials_ShouldStoreCorrectly()
    {
        var request = PurchaseRequestData.CreateRequest(
            quantity: new Quantity(25000, new UnitOfMeasure("Kilogram")),
            unitOfMeasure: new UnitOfMeasure("Kilogram"),
            requestedDeliveryDate: new DateOnly(2026, 4, 1),
            purchasingGroup: "CONSTRUCTION",
            orderStatus: OrderStatus.Created);

        request.PurchasingGroup.Should().Be("CONSTRUCTION");
        request.Quantity.Amount.Should().Be(25000);
    }
}