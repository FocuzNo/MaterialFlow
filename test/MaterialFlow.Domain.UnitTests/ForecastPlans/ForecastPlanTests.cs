using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.ForecastPlans.Events;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.UnitTests.Infrastructure;

namespace MaterialFlow.Domain.UnitTests.ForecastPlans;

public sealed class ForecastPlanTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializePlan_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var planningAreaId = Guid.NewGuid();
        var version = "2.5.1";
        var planningStrategy = "JIT";
        var unitOfMeasure = new UnitOfMeasure("Liter");
        var periodGranularity = PeriodGranularity.Week;
        var dateRange = new DateRange(
            new DateOnly(2025, 3, 1),
            new DateOnly(2026, 2, 28));

        var plan = ForecastPlan.Create(
            id,
            materialId,
            siteId,
            planningAreaId,
            version,
            planningStrategy,
            unitOfMeasure,
            periodGranularity,
            dateRange);

        plan.Id.Should().Be(id);
        plan.MaterialId.Should().Be(materialId);
        plan.SiteId.Should().Be(siteId);
        plan.PlanningAreaId.Should().Be(planningAreaId);
        plan.Version.Should().Be(version);
        plan.PlanningStrategy.Should().Be(planningStrategy);
        plan.UnitOfMeasure.Should().Be(unitOfMeasure);
        plan.PeriodGranularity.Should().Be(periodGranularity);
        plan.DateRange.Should().Be(dateRange);
        plan.Items.Should().BeEmpty();
    }

    [Fact]
    public void Create_ShouldRaise_ForecastPlanCreatedDomainEvent()
    {
        var plan = ForecastPlanData.CreatePlan();

        AssertDomainEventWasPublished<ForecastPlanCreatedDomainEvent>(plan);
    }

    [Fact]
    public void AddItem_ShouldAddItemToCollection()
    {
        var plan = ForecastPlanData.CreatePlan();
        var periodStartDate = new DateOnly(2025, 8, 1);
        var quantity = new Quantity(450, new UnitOfMeasure("Kilogram"));

        var item = plan.AddItem(periodStartDate, quantity);

        plan.Items.Should().ContainSingle();
        plan.Items.Should().Contain(item);
        item.ForecastPlanId.Should().Be(plan.Id);
        item.PeriodStartDate.Should().Be(periodStartDate);
        item.Quantity.Should().Be(quantity);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var plan = ForecastPlanData.CreatePlan();
        var newVersion = "3.0.0";
        var newPlanningStrategy = "Make-to-Stock";
        var newUnitOfMeasure = new UnitOfMeasure("Box");
        var newPeriodGranularity = PeriodGranularity.Day;
        var newDateRange = new DateRange(
            new DateOnly(2026, 6, 1),
            new DateOnly(2027, 5, 31));

        plan.Update(newVersion, newPlanningStrategy, newUnitOfMeasure, newPeriodGranularity, newDateRange);

        plan.Version.Should().Be(newVersion);
        plan.PlanningStrategy.Should().Be(newPlanningStrategy);
        plan.UnitOfMeasure.Should().Be(newUnitOfMeasure);
        plan.PeriodGranularity.Should().Be(newPeriodGranularity);
        plan.DateRange.Should().Be(newDateRange);
    }

    [Fact]
    public void Update_ShouldRaise_ForecastPlanUpdatedDomainEvent()
    {
        var plan = ForecastPlanData.CreatePlan();
        plan.ClearDomainEvents();

        plan.Update(
            "4.1.2",
            "Lean Manufacturing",
            new UnitOfMeasure("Pallet"),
            PeriodGranularity.Month,
            new DateRange(new DateOnly(2027, 1, 1), new DateOnly(2027, 12, 31)));

        AssertDomainEventWasPublished<ForecastPlanUpdatedDomainEvent>(plan);
    }

    [Fact]
    public void Delete_ShouldRaise_ForecastPlanDeletedDomainEvent()
    {
        var plan = ForecastPlanData.CreatePlan();
        plan.ClearDomainEvents();

        plan.Delete();

        AssertDomainEventWasPublished<ForecastPlanDeletedDomainEvent>(plan);
    }
}