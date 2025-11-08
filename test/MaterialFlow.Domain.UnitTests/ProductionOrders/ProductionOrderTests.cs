using MaterialFlow.Domain.ProductionOrders;
using MaterialFlow.Domain.ProductionOrders.Events;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ProductionOrders;

public sealed class ProductionOrderTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeOrder_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var plannedOrderId = Guid.NewGuid();
        var quantityToProduce = new Quantity(5000, new UnitOfMeasure("Piece"));
        var unitOfMeasure = new UnitOfMeasure("Piece");
        var scheduledStartDate = new DateOnly(2025, 12, 1);
        var scheduledEndDate = new DateOnly(2025, 12, 15);
        var orderStatus = OrderStatus.Created;

        var order = ProductionOrder.Create(
            id,
            materialId,
            siteId,
            plannedOrderId,
            quantityToProduce,
            unitOfMeasure,
            scheduledStartDate,
            scheduledEndDate,
            orderStatus);

        order.Id.Should().Be(id);
        order.MaterialId.Should().Be(materialId);
        order.SiteId.Should().Be(siteId);
        order.PlannedProductionOrderId.Should().Be(plannedOrderId);
        order.QuantityToProduce.Should().Be(quantityToProduce);
        order.UnitOfMeasure.Should().Be(unitOfMeasure);
        order.ScheduledStartDate.Should().Be(scheduledStartDate);
        order.ScheduledEndDate.Should().Be(scheduledEndDate);
        order.OrderStatus.Should().Be(orderStatus);
    }

    [Fact]
    public void Create_ShouldRaise_ProductionOrderCreatedDomainEvent()
    {
        var order = ProductionOrderData.CreateOrder();

        AssertDomainEventWasPublished<ProductionOrderCreatedDomainEvent>(order);
    }

    [Fact]
    public void Create_WithoutPlannedProductionOrder_ShouldBeNull()
    {
        var order = ProductionOrderData.CreateOrder();

        order.PlannedProductionOrderId.Should().BeNull();
        order.PlannedProductionOrder.Should().BeNull();
    }

    [Fact]
    public void Create_ForLargeQuantity_ShouldStoreCorrectly()
    {
        var order = ProductionOrderData.CreateOrder(
            quantityToProduce: new Quantity(50000, new UnitOfMeasure("Kilogram")),
            unitOfMeasure: new UnitOfMeasure("Kilogram"),
            scheduledStartDate: new DateOnly(2026, 1, 5),
            scheduledEndDate: new DateOnly(2026, 2, 20));

        order.QuantityToProduce.Amount.Should().Be(50000);
    }

    [Fact]
    public void Create_ForSmallBatch_ShouldStoreCorrectly()
    {
        var order = ProductionOrderData.CreateOrder(
            quantityToProduce: new Quantity(25, new UnitOfMeasure("Piece")),
            unitOfMeasure: new UnitOfMeasure("Piece"),
            scheduledStartDate: new DateOnly(2025, 11, 10),
            scheduledEndDate: new DateOnly(2025, 11, 12));

        order.QuantityToProduce.Amount.Should().Be(25);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var order = ProductionOrderData.CreateOrder();
        var newQuantity = new Quantity(7500, new UnitOfMeasure("Liter"));
        var newStartDate = new DateOnly(2026, 3, 10);
        var newEndDate = new DateOnly(2026, 3, 25);
        var newStatus = OrderStatus.Open;

        order.Update(newQuantity, newStartDate, newEndDate, newStatus);

        order.QuantityToProduce.Should().Be(newQuantity);
        order.ScheduledStartDate.Should().Be(newStartDate);
        order.ScheduledEndDate.Should().Be(newEndDate);
        order.OrderStatus.Should().Be(newStatus);
    }

    [Fact]
    public void Update_ShouldRaise_ProductionOrderUpdatedDomainEvent()
    {
        var order = ProductionOrderData.CreateOrder();
        order.ClearDomainEvents();

        order.Update(
            new Quantity(3000, new UnitOfMeasure("Ton")),
            new DateOnly(2026, 5, 1),
            new DateOnly(2026, 5, 30),
            OrderStatus.Open);

        AssertDomainEventWasPublished<ProductionOrderUpdatedDomainEvent>(order);
    }

    [Fact]
    public void Update_ShouldNotModify_ImmutableProperties()
    {
        var order = ProductionOrderData.CreateOrder();
        var originalMaterialId = order.MaterialId;
        var originalSiteId = order.SiteId;
        var originalPlannedOrderId = order.PlannedProductionOrderId;
        var originalUnitOfMeasure = order.UnitOfMeasure;

        order.Update(
            new Quantity(2000, new UnitOfMeasure("Piece")),
            new DateOnly(2026, 6, 15),
            new DateOnly(2026, 7, 5),
            OrderStatus.Closed);

        order.MaterialId.Should().Be(originalMaterialId);
        order.SiteId.Should().Be(originalSiteId);
        order.PlannedProductionOrderId.Should().Be(originalPlannedOrderId);
        order.UnitOfMeasure.Should().Be(originalUnitOfMeasure);
    }

    [Fact]
    public void Cancel_ShouldSetStatusToCancelled()
    {
        var order = ProductionOrderData.CreateOrder();

        order.Cancel();

        order.OrderStatus.Should().Be(OrderStatus.Cancelled);
    }

    [Fact]
    public void Cancel_ShouldRaise_ProductionOrderCancelledDomainEvent()
    {
        var order = ProductionOrderData.CreateOrder();
        order.ClearDomainEvents();

        order.Cancel();

        AssertDomainEventWasPublished<ProductionOrderCancelledDomainEvent>(order);
    }

    [Fact]
    public void Cancel_WhenAlreadyCancelled_ShouldNotRaiseDomainEvent()
    {
        var order = ProductionOrderData.CreateOrder();
        order.Cancel();
        order.ClearDomainEvents();

        order.Cancel();

        order.GetDomainEvents().Should().BeEmpty();
    }

    [Fact]
    public void Cancel_WhenCalledMultipleTimes_ShouldBeIdempotent()
    {
        var order = ProductionOrderData.CreateOrder();

        order.Cancel();
        order.Cancel();
        order.Cancel();

        order.OrderStatus.Should().Be(OrderStatus.Cancelled);
    }

    [Fact]
    public void Create_WithShortProductionCycle_ShouldStoreCorrectly()
    {
        var order = ProductionOrderData.CreateOrder(
            quantityToProduce: new Quantity(500, new UnitOfMeasure("Box")),
            unitOfMeasure: new UnitOfMeasure("Box"),
            scheduledStartDate: new DateOnly(2025, 11, 20),
            scheduledEndDate: new DateOnly(2025, 11, 22));

        var duration = order.ScheduledEndDate.DayNumber - order.ScheduledStartDate.DayNumber;
        duration.Should().Be(2);
    }

    [Fact]
    public void Create_WithLongProductionCycle_ShouldStoreCorrectly()
    {
        var order = ProductionOrderData.CreateOrder(
            quantityToProduce: new Quantity(100000, new UnitOfMeasure("Piece")),
            unitOfMeasure: new UnitOfMeasure("Piece"),
            scheduledStartDate: new DateOnly(2026, 1, 1),
            scheduledEndDate: new DateOnly(2026, 3, 31));

        var duration = order.ScheduledEndDate.DayNumber - order.ScheduledStartDate.DayNumber;
        duration.Should().Be(89);
    }

    [Fact]
    public void Update_FromCreatedToOpen_ShouldUpdateStatus()
    {
        var order = ProductionOrderData.CreateOrder(orderStatus: OrderStatus.Created);

        order.Update(
            order.QuantityToProduce,
            order.ScheduledStartDate,
            order.ScheduledEndDate,
            OrderStatus.Open);

        order.OrderStatus.Should().Be(OrderStatus.Open);
    }

    [Fact]
    public void Update_FromOpenToClosed_ShouldUpdateStatus()
    {
        var order = ProductionOrderData.CreateOrder(orderStatus: OrderStatus.Open);

        order.Update(
            order.QuantityToProduce,
            order.ScheduledStartDate,
            order.ScheduledEndDate,
            OrderStatus.Closed);

        order.OrderStatus.Should().Be(OrderStatus.Closed);
    }

    [Fact]
    public void Create_WithPlannedProductionOrder_ShouldLinkCorrectly()
    {
        var plannedOrderId = Guid.NewGuid();

        var order = ProductionOrderData.CreateOrder(plannedProductionOrderId: plannedOrderId);

        order.PlannedProductionOrderId.Should().Be(plannedOrderId);
    }
}