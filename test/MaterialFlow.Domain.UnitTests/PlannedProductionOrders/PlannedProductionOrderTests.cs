using MaterialFlow.Domain.PlannedProductionOrders;
using MaterialFlow.Domain.PlannedProductionOrders.Events;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.PlannedProductionOrders;

public sealed class PlannedProductionOrderTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeOrder_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var planningRunId = Guid.NewGuid();
        var quantity = 2500m;
        var unitOfMeasure = new UnitOfMeasure("Kilogram");
        var startDate = new DateOnly(2025, 11, 15);
        var endDate = new DateOnly(2025, 11, 29);
        var orderStatus = OrderStatus.Created;

        var order = PlannedProductionOrder.Create(
            id,
            materialId,
            siteId,
            planningRunId,
            quantity,
            unitOfMeasure,
            startDate,
            endDate,
            orderStatus);

        order.Id.Should().Be(id);
        order.MaterialId.Should().Be(materialId);
        order.SiteId.Should().Be(siteId);
        order.PlanningRunId.Should().Be(planningRunId);
        order.Quantity.Should().Be(quantity);
        order.UnitOfMeasure.Should().Be(unitOfMeasure);
        order.StartDate.Should().Be(startDate);
        order.EndDate.Should().Be(endDate);
        order.OrderStatus.Should().Be(orderStatus);
    }

    [Fact]
    public void Create_ShouldRaise_PlannedProductionOrderCreatedDomainEvent()
    {
        var order = PlannedProductionOrderData.CreateOrder();

        AssertDomainEventWasPublished<PlannedProductionOrderCreatedDomainEvent>(order);
    }

    [Fact]
    public void Create_WithoutPlanningRunId_ShouldBeNull()
    {
        var order = PlannedProductionOrderData.CreateOrder();

        order.PlanningRunId.Should().BeNull();
        order.PlanningRun.Should().BeNull();
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var order = PlannedProductionOrderData.CreateOrder();
        var newQuantity = 5000m;
        var newStartDate = new DateOnly(2026, 1, 10);
        var newEndDate = new DateOnly(2026, 2, 15);
        var newOrderStatus = OrderStatus.Open;

        order.Update(newQuantity, newStartDate, newEndDate, newOrderStatus);

        order.Quantity.Should().Be(newQuantity);
        order.StartDate.Should().Be(newStartDate);
        order.EndDate.Should().Be(newEndDate);
        order.OrderStatus.Should().Be(newOrderStatus);
    }

    [Fact]
    public void Update_ShouldRaise_PlannedProductionOrderApprovedDomainEvent()
    {
        var order = PlannedProductionOrderData.CreateOrder();
        order.ClearDomainEvents();

        order.Update(
            7500m,
            new DateOnly(2026, 3, 1),
            new DateOnly(2026, 3, 21),
            OrderStatus.Open);

        AssertDomainEventWasPublished<PlannedProductionOrderApprovedDomainEvent>(order);
    }

    [Fact]
    public void Update_ShouldNotModify_OtherProperties()
    {
        var order = PlannedProductionOrderData.CreateOrder();
        var originalMaterialId = order.MaterialId;
        var originalSiteId = order.SiteId;
        var originalPlanningRunId = order.PlanningRunId;
        var originalUnitOfMeasure = order.UnitOfMeasure;

        order.Update(
            1250m,
            new DateOnly(2026, 5, 5),
            new DateOnly(2026, 5, 25),
            OrderStatus.Closed);

        order.MaterialId.Should().Be(originalMaterialId);
        order.SiteId.Should().Be(originalSiteId);
        order.PlanningRunId.Should().Be(originalPlanningRunId);
        order.UnitOfMeasure.Should().Be(originalUnitOfMeasure);
    }

    [Fact]
    public void Cancel_ShouldSetStatusToCancelled()
    {
        var order = PlannedProductionOrderData.CreateOrder();

        order.Cancel();

        order.OrderStatus.Should().Be(OrderStatus.Cancelled);
    }

    [Fact]
    public void Cancel_ShouldRaise_PlannedProductionOrderCancelledDomainEvent()
    {
        var order = PlannedProductionOrderData.CreateOrder();
        order.ClearDomainEvents();

        order.Cancel();

        AssertDomainEventWasPublished<PlannedProductionOrderCancelledDomainEvent>(order);
    }

    [Fact]
    public void Cancel_WhenAlreadyCancelled_ShouldNotRaiseDomainEvent()
    {
        var order = PlannedProductionOrderData.CreateOrder();
        order.Cancel();
        order.ClearDomainEvents();

        order.Cancel();

        order.GetDomainEvents().Should().BeEmpty();
    }

    [Fact]
    public void Cancel_WhenCalledMultipleTimes_ShouldBeIdempotent()
    {
        var order = PlannedProductionOrderData.CreateOrder();

        order.Cancel();
        order.Cancel();
        order.Cancel();

        order.OrderStatus.Should().Be(OrderStatus.Cancelled);
    }
}