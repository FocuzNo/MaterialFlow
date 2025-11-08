using MaterialFlow.Domain.PlanningRunLines;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.PlanningRunLines;

public sealed class PlanningRunLineTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeLine_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var planningRunId = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var requirementDate = new DateOnly(2025, 12, 10);
        var requirementQuantity = new Quantity(5000, new UnitOfMeasure("Kilogram"));
        var availableQuantity = new Quantity(3200, new UnitOfMeasure("Kilogram"));
        var shortageQuantity = new Quantity(1800, new UnitOfMeasure("Kilogram"));
        var recommendedAction = "Expedite Purchase Order - Critical Shortage";
        var rescheduleDate = new DateOnly(2025, 12, 8);

        var line = PlanningRunLine.Create(
            id,
            planningRunId,
            materialId,
            siteId,
            requirementDate,
            requirementQuantity,
            availableQuantity,
            shortageQuantity,
            recommendedAction,
            rescheduleDate);

        line.Id.Should().Be(id);
        line.PlanningRunId.Should().Be(planningRunId);
        line.MaterialId.Should().Be(materialId);
        line.SiteId.Should().Be(siteId);
        line.RequirementDate.Should().Be(requirementDate);
        line.RequirementQuantity.Should().Be(requirementQuantity);
        line.AvailableQuantity.Should().Be(availableQuantity);
        line.ShortageQuantity.Should().Be(shortageQuantity);
        line.RecommendedAction.Should().Be(recommendedAction);
        line.RescheduleDate.Should().Be(rescheduleDate);
    }

    [Fact]
    public void Create_WithNoShortage_ShouldHaveZeroShortageQuantity()
    {
        var requirementQty = new Quantity(1000, new UnitOfMeasure("Piece"));
        var availableQty = new Quantity(1200, new UnitOfMeasure("Piece"));
        var shortageQty = new Quantity(0, new UnitOfMeasure("Piece"));

        var line = PlanningRunLineData.CreateLine(
            requirementQuantity: requirementQty,
            availableQuantity: availableQty,
            shortageQuantity: shortageQty,
            recommendedAction: "No Action Required - Sufficient Stock");

        line.ShortageQuantity.Amount.Should().Be(0);
        line.RecommendedAction.Should().Be("No Action Required - Sufficient Stock");
    }

    [Fact]
    public void Create_WithCriticalShortage_ShouldReflectUrgentAction()
    {
        var line = PlanningRunLineData.CreateLine(
            requirementQuantity: new Quantity(10000, new UnitOfMeasure("Liter")),
            availableQuantity: new Quantity(500, new UnitOfMeasure("Liter")),
            shortageQuantity: new Quantity(9500, new UnitOfMeasure("Liter")),
            recommendedAction: "Emergency Procurement - Production at Risk",
            rescheduleDate: new DateOnly(2025, 11, 20));

        line.ShortageQuantity.Amount.Should().Be(9500);
        line.RecommendedAction.Should().Contain("Emergency");
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var line = PlanningRunLineData.CreateLine();
        var newRequirementDate = new DateOnly(2026, 2, 15);
        var newRequirementQuantity = new Quantity(7500, new UnitOfMeasure("Ton"));
        var newAvailableQuantity = new Quantity(6000, new UnitOfMeasure("Ton"));
        var newShortageQuantity = new Quantity(1500, new UnitOfMeasure("Ton"));
        var newRecommendedAction = "Transfer from Alternative Site";
        var newRescheduleDate = new DateOnly(2026, 2, 10);

        line.Update(
            newRequirementDate,
            newRequirementQuantity,
            newAvailableQuantity,
            newShortageQuantity,
            newRecommendedAction,
            newRescheduleDate);

        line.RequirementQuantity.Should().Be(newRequirementQuantity);
        line.AvailableQuantity.Should().Be(newAvailableQuantity);
        line.ShortageQuantity.Should().Be(newShortageQuantity);
        line.RecommendedAction.Should().Be(newRecommendedAction);
        line.RescheduleDate.Should().Be(newRescheduleDate);
    }

    [Fact]
    public void Update_ShouldNotModify_ImmutableProperties()
    {
        var line = PlanningRunLineData.CreateLine();
        var originalPlanningRunId = line.PlanningRunId;
        var originalMaterialId = line.MaterialId;
        var originalSiteId = line.SiteId;
        var originalRequirementDate = line.RequirementDate;

        line.Update(
            new DateOnly(2026, 5, 1),
            new Quantity(3000, new UnitOfMeasure("Box")),
            new Quantity(2500, new UnitOfMeasure("Box")),
            new Quantity(500, new UnitOfMeasure("Box")),
            "Production Reschedule",
            new DateOnly(2026, 4, 28));

        line.PlanningRunId.Should().Be(originalPlanningRunId);
        line.MaterialId.Should().Be(originalMaterialId);
        line.SiteId.Should().Be(originalSiteId);
        line.RequirementDate.Should().Be(originalRequirementDate);
    }

    [Fact]
    public void Update_WithResolvedShortage_ShouldUpdateToNoAction()
    {
        var line = PlanningRunLineData.CreateLine(
            shortageQuantity: new Quantity(500, new UnitOfMeasure("Piece")),
            recommendedAction: "Purchase Order Required");

        line.Update(
            line.RequirementDate,
            new Quantity(1000, new UnitOfMeasure("Piece")),
            new Quantity(1000, new UnitOfMeasure("Piece")),
            new Quantity(0, new UnitOfMeasure("Piece")),
            "Shortage Resolved - No Action",
            line.RequirementDate);

        line.ShortageQuantity.Amount.Should().Be(0);
        line.RecommendedAction.Should().Contain("Resolved");
    }

    [Fact]
    public void Create_WithRescheduleEarlierThanRequirement_ShouldStoreCorrectly()
    {
        var requirementDate = new DateOnly(2025, 12, 25);
        var rescheduleDate = new DateOnly(2025, 12, 18);

        var line = PlanningRunLineData.CreateLine(
            requirementDate: requirementDate,
            rescheduleDate: rescheduleDate,
            recommendedAction: "Advance Production Schedule");

        line.RescheduleDate.Should().Be(rescheduleDate);
        line.RescheduleDate.Should().BeBefore(line.RequirementDate);
    }

    [Fact]
    public void Create_WithMultipleRecommendations_ShouldStoreConcatenated()
    {
        var complexAction = "1) Issue Purchase Order, 2) Expedite Supplier Delivery, 3) Monitor Daily Stock Levels";

        var line = PlanningRunLineData.CreateLine(recommendedAction: complexAction);

        line.RecommendedAction.Should().Be(complexAction);
    }
}