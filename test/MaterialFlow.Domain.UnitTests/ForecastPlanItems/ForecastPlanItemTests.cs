using MaterialFlow.Domain.ForecastPlanItems;
using MaterialFlow.Domain.ForecastPlanItems.Events;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.UnitTests.Infrastructure;

namespace MaterialFlow.Domain.UnitTests.ForecastPlanItems;

public sealed class ForecastPlanItemTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeItem_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var forecastPlanId = Guid.NewGuid();
        var periodStartDate = new DateOnly(2025, 6, 1);
        var quantity = new Quantity(1500, new UnitOfMeasure("Meter"));
        var consumptionIndicator = "Quarterly";

        var item = ForecastPlanItem.Create(
            id,
            forecastPlanId,
            periodStartDate,
            quantity,
            consumptionIndicator);

        item.Id.Should().Be(id);
        item.ForecastPlanId.Should().Be(forecastPlanId);
        item.PeriodStartDate.Should().Be(periodStartDate);
        item.Quantity.Should().Be(quantity);
        item.ConsumptionIndicator.Should().Be(consumptionIndicator);
    }

    [Fact]
    public void Create_ShouldRaise_ForecastPlanItemCreatedDomainEvent()
    {
        var item = ForecastPlanItemData.CreateItem();

        AssertDomainEventWasPublished<ForecastPlanItemCreatedDomainEvent>(item);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var item = ForecastPlanItemData.CreateItem();
        var newPeriodStartDate = new DateOnly(2026, 9, 15);
        var newQuantity = new Quantity(3200, new UnitOfMeasure("Ton"));
        var newConsumptionIndicator = "Annually";

        item.Update(newPeriodStartDate, newQuantity, newConsumptionIndicator);

        item.PeriodStartDate.Should().Be(newPeriodStartDate);
        item.Quantity.Should().Be(newQuantity);
        item.ConsumptionIndicator.Should().Be(newConsumptionIndicator);
    }

    [Fact]
    public void Update_ShouldRaise_ForecastPlanItemUpdatedDomainEvent()
    {
        var item = ForecastPlanItemData.CreateItem();
        item.ClearDomainEvents();

        item.Update(
            new DateOnly(2026, 4, 10),
            new Quantity(800, new UnitOfMeasure("Piece")),
            "Biweekly");

        AssertDomainEventWasPublished<ForecastPlanItemUpdatedDomainEvent>(item);
    }

    [Fact]
    public void Delete_ShouldRaise_ForecastPlanItemDeletedDomainEvent()
    {
        var item = ForecastPlanItemData.CreateItem();
        item.ClearDomainEvents();

        item.Delete();

        AssertDomainEventWasPublished<ForecastPlanItemDeletedDomainEvent>(item);
    }
}