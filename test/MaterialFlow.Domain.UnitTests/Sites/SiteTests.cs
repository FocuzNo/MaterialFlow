using MaterialFlow.Domain.Sites;
using MaterialFlow.Domain.UnitTests.Infrastructure;

namespace MaterialFlow.Domain.UnitTests.Sites;

public sealed class SiteTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeSite_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var plantCode = "NORTH-PLANT-2025";
        var name = "Northern Manufacturing Complex";

        var site = Site.Create(id, plantCode, name);

        site.Id.Should().Be(id);
        site.PlantCode.Should().Be(plantCode);
        site.Name.Should().Be(name);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var site = SiteData.CreateSite();
        var newPlantCode = "SOUTH-FACILITY";
        var newName = "Southern Distribution Center";

        site.Update(newPlantCode, newName);

        site.PlantCode.Should().Be(newPlantCode);
        site.Name.Should().Be(newName);
    }

    [Fact]
    public void Create_ForManufacturingPlant_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "MFG-001",
            name: "Primary Assembly Plant - Detroit");

        site.PlantCode.Should().Be("MFG-001");
        site.Name.Should().Contain("Detroit");
    }

    [Fact]
    public void Create_ForWarehouse_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "WH-CENTRAL",
            name: "Central Warehouse and Logistics Hub");

        site.PlantCode.Should().Be("WH-CENTRAL");
        site.Name.Should().Contain("Warehouse");
    }

    [Fact]
    public void Create_ForDistributionCenter_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "DC-WEST-01",
            name: "Western Regional Distribution Center");

        site.PlantCode.Should().Be("DC-WEST-01");
        site.Name.Should().Contain("Distribution");
    }

    [Fact]
    public void Create_ForProductionFacility_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "PROD-EU-DE-001",
            name: "European Production Facility - Munich");

        site.PlantCode.Should().Be("PROD-EU-DE-001");
        site.Name.Should().Contain("Munich");
    }

    [Fact]
    public void Create_ForAssemblyLine_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "ASM-LINE-5",
            name: "Advanced Assembly Line 5 - Electronics Division");

        site.PlantCode.Should().Contain("ASM");
        site.Name.Should().Contain("Electronics");
    }

    [Fact]
    public void Update_WithNewCodeAndName_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "OLD-PLANT",
            name: "Old Manufacturing Site");

        site.Update("MODERNIZED-PLANT-2026", "Modernized Smart Factory");

        site.PlantCode.Should().Be("MODERNIZED-PLANT-2026");
        site.Name.Should().Be("Modernized Smart Factory");
    }

    [Fact]
    public void Create_ForOffshoreLocation_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "OFFSHORE-CN-SH",
            name: "China Production Plant - Shanghai");

        site.PlantCode.Should().Be("OFFSHORE-CN-SH");
        site.Name.Should().Contain("Shanghai");
    }

    [Fact]
    public void Create_ForRAndDCenter_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "RND-INNOVATION",
            name: "Research and Development Innovation Center");

        site.PlantCode.Should().Be("RND-INNOVATION");
        site.Name.Should().Contain("Innovation");
    }

    [Fact]
    public void Create_WithShortCode_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(plantCode: "P1");

        site.PlantCode.Should().Be("P1");
    }

    [Fact]
    public void Create_WithLongDescriptiveName_ShouldStoreCorrectly()
    {
        var longName = "Global Headquarters Manufacturing and Distribution Excellence Center of Operations";

        var site = SiteData.CreateSite(name: longName);

        site.Name.Should().Be(longName);
    }

    [Fact]
    public void Update_MultipleTimesSequentially_ShouldRetainLastValues()
    {
        var site = SiteData.CreateSite();

        site.Update("TEMP-001", "Temporary Location");
        site.Update("INTERIM-002", "Interim Facility");

        var finalCode = "PERMANENT-PLANT";
        var finalName = "Permanent Manufacturing Facility";

        site.Update(finalCode, finalName);

        site.PlantCode.Should().Be(finalCode);
        site.Name.Should().Be(finalName);
    }

    [Fact]
    public void Create_ForRegionalHub_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "HUB-EMEA-001",
            name: "EMEA Regional Hub - Frankfurt");

        site.PlantCode.Should().Be("HUB-EMEA-001");
        site.Name.Should().Contain("EMEA");
    }

    [Fact]
    public void Create_ForSatelliteFacility_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "SAT-REMOTE-07",
            name: "Satellite Production Unit - Remote Location");

        site.PlantCode.Should().Be("SAT-REMOTE-07");
        site.Name.Should().Contain("Satellite");
    }

    [Fact]
    public void Create_ForCrossDockCenter_ShouldStoreCorrectly()
    {
        var site = SiteData.CreateSite(
            plantCode: "XD-LOGISTICS",
            name: "Cross-Dock Logistics Center");

        site.PlantCode.Should().Be("XD-LOGISTICS");
        site.Name.Should().Contain("Cross-Dock");
    }

    [Fact]
    public void Update_CanRenameExistingPlant()
    {
        var site = SiteData.CreateSite(
            plantCode: "PLANT-A",
            name: "Plant A");

        site.Update("PLANT-A", "Plant A - Expanded Operations Center");

        site.PlantCode.Should().Be("PLANT-A");
        site.Name.Should().Contain("Expanded");
    }
}