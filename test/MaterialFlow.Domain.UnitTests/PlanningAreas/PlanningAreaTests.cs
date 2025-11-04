using MaterialFlow.Domain.PlanningAreas;
using MaterialFlow.Domain.UnitTests.Infrastructure;

namespace MaterialFlow.Domain.UnitTests.PlanningAreas;

public sealed class PlanningAreaTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeArea_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var planningAreaCode = "PA-NORTH-2025";
        var description = "Northern Region Manufacturing Planning Area";
        var siteId = Guid.NewGuid();

        var area = PlanningArea.Create(id, planningAreaCode, description, siteId);

        area.Id.Should().Be(id);
        area.PlanningAreaCode.Should().Be(planningAreaCode);
        area.Description.Should().Be(description);
        area.SiteId.Should().Be(siteId);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var area = PlanningAreaData.CreateArea();
        var newPlanningAreaCode = "PA-SOUTH-CENTRAL";
        var newDescription = "South Central Distribution Planning Zone";
        var newSiteId = Guid.NewGuid();

        area.Update(newPlanningAreaCode, newDescription, newSiteId);

        area.PlanningAreaCode.Should().Be(newPlanningAreaCode);
        area.Description.Should().Be(newDescription);
        area.SiteId.Should().Be(newSiteId);
    }

    [Fact]
    public void Update_CanChangeSiteId()
    {
        var area = PlanningAreaData.CreateArea();
        var originalSiteId = area.SiteId;
        var newSiteId = Guid.NewGuid();

        area.Update("PA-RELOCATED", "Relocated Planning Area", newSiteId);

        area.SiteId.Should().NotBe(originalSiteId);
        area.SiteId.Should().Be(newSiteId);
    }

    [Fact]
    public void Update_WithDifferentCode_ShouldUpdateSuccessfully()
    {
        var area = PlanningAreaData.CreateArea(planningAreaCode: "PA-TEMP-001");

        area.Update(
            "PA-ASSEMBLY-WEST",
            "Western Assembly Line Planning Sector",
            area.SiteId);

        area.PlanningAreaCode.Should().Be("PA-ASSEMBLY-WEST");
    }

    [Fact]
    public void Create_WithLongDescription_ShouldStoreCorrectly()
    {
        var longDescription = "Advanced Manufacturing Excellence Center - High-Volume Production Planning and Scheduling Coordination Area for Automotive Component Assembly Operations";

        var area = PlanningAreaData.CreateArea(description: longDescription);

        area.Description.Should().Be(longDescription);
    }

    [Fact]
    public void Create_WithShortCode_ShouldStoreCorrectly()
    {
        var area = PlanningAreaData.CreateArea(planningAreaCode: "PA-1");

        area.PlanningAreaCode.Should().Be("PA-1");
    }

    [Fact]
    public void Update_MultipleTimesSequentially_ShouldRetainLastValues()
    {
        var area = PlanningAreaData.CreateArea();

        area.Update("PA-V1", "Version 1", Guid.NewGuid());
        area.Update("PA-V2", "Version 2", Guid.NewGuid());
        var finalCode = "PA-FINAL-VERSION";
        var finalDescription = "Final Production Planning Area";
        var finalSiteId = Guid.NewGuid();

        area.Update(finalCode, finalDescription, finalSiteId);

        area.PlanningAreaCode.Should().Be(finalCode);
        area.Description.Should().Be(finalDescription);
        area.SiteId.Should().Be(finalSiteId);
    }
}