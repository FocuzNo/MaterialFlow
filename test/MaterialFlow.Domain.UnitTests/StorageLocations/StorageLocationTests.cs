using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Domain.UnitTests.StorageLocations;

public sealed class StorageLocationTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeStorageLocation_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var code = "WH-NORTH-A1-01";
        var name = "Warehouse North - Zone A1 - Rack 01";

        var storageLocation = StorageLocation.Create(id, siteId, code, name);

        storageLocation.Id.Should().Be(id);
        storageLocation.SiteId.Should().Be(siteId);
        storageLocation.Code.Should().Be(code);
        storageLocation.Name.Should().Be(name);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation();
        var newCode = "WH-SOUTH-B2-05";
        var newName = "Warehouse South - Zone B2 - Rack 05";

        storageLocation.Update(newCode, newName);

        storageLocation.Code.Should().Be(newCode);
        storageLocation.Name.Should().Be(newName);
    }

    [Fact]
    public void Create_ForWarehouseRack_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "RACK-A1-01",
            name: "Pallet Rack A1 - Position 01");

        storageLocation.Code.Should().Be("RACK-A1-01");
        storageLocation.Name.Should().Contain("Pallet Rack");
    }

    [Fact]
    public void Create_ForBinLocation_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "BIN-12-A-05",
            name: "Small Parts Bin - Aisle 12A - Position 05");

        storageLocation.Code.Should().Be("BIN-12-A-05");
        storageLocation.Name.Should().Contain("Small Parts Bin");
    }

    [Fact]
    public void Create_ForShelvingUnit_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "SHELF-Z3-L2-B8",
            name: "Shelving Unit Zone 3 - Level 2 - Bay 8");

        storageLocation.Code.Should().Be("SHELF-Z3-L2-B8");
        storageLocation.Name.Should().Contain("Shelving Unit");
    }

    [Fact]
    public void Create_ForPickingLocation_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "PICK-ZONE-A-15",
            name: "Fast Pick Zone A - Location 15");

        storageLocation.Code.Should().Be("PICK-ZONE-A-15");
        storageLocation.Name.Should().Contain("Pick Zone");
    }

    [Fact]
    public void Create_ForBulkStorage_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "BULK-FL-01",
            name: "Bulk Floor Storage Area 01");

        storageLocation.Code.Should().Contain("BULK");
        storageLocation.Name.Should().Contain("Floor Storage");
    }

    [Fact]
    public void Create_ForColdStorage_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "COLD-RM-A-03",
            name: "Cold Storage Room A - Section 03");

        storageLocation.Code.Should().Be("COLD-RM-A-03");
        storageLocation.Name.Should().Contain("Cold Storage");
    }

    [Fact]
    public void Update_WithNewCodeAndName_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "OLD-LOC-01",
            name: "Old Storage Location");

        storageLocation.Update("NEW-ZONE-A1-01", "Modernized Storage Zone A1-01");

        storageLocation.Code.Should().Be("NEW-ZONE-A1-01");
        storageLocation.Name.Should().Be("Modernized Storage Zone A1-01");
    }

    [Fact]
    public void Create_ForQuarantineArea_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "QUAR-AREA-02",
            name: "Quarantine Inspection Area 02");

        storageLocation.Code.Should().Be("QUAR-AREA-02");
        storageLocation.Name.Should().Contain("Quarantine");
    }

    [Fact]
    public void Create_ForStagingArea_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "STAGE-OUT-07",
            name: "Outbound Staging Area 07");

        storageLocation.Code.Should().Be("STAGE-OUT-07");
        storageLocation.Name.Should().Contain("Staging");
    }

    [Fact]
    public void Create_WithShortCode_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(code: "L1");

        storageLocation.Code.Should().Be("L1");
    }

    [Fact]
    public void Create_WithLongDescriptiveName_ShouldStoreCorrectly()
    {
        var longName = "High-Density Automated Storage and Retrieval System - Aisle 12 - Level 5 - Position 24";

        var storageLocation = StorageLocationData.CreateStorageLocation(name: longName);

        storageLocation.Name.Should().Be(longName);
    }

    [Fact]
    public void Update_MultipleTimesSequentially_ShouldRetainLastValues()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation();

        storageLocation.Update("TEMP-01", "Temporary Location");
        storageLocation.Update("INTERIM-02", "Interim Storage");

        var finalCode = "PERM-A1-05";
        var finalName = "Permanent Storage - Zone A1 - Position 05";

        storageLocation.Update(finalCode, finalName);

        storageLocation.Code.Should().Be(finalCode);
        storageLocation.Name.Should().Be(finalName);
    }

    [Fact]
    public void Create_ForDockDoor_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "DOCK-12",
            name: "Loading Dock Door 12");

        storageLocation.Code.Should().Be("DOCK-12");
        storageLocation.Name.Should().Contain("Dock");
    }

    [Fact]
    public void Create_ForMezzanineLevel_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "MEZZ-L2-A3",
            name: "Mezzanine Level 2 - Area A3");

        storageLocation.Code.Should().Be("MEZZ-L2-A3");
        storageLocation.Name.Should().Contain("Mezzanine");
    }

    [Fact]
    public void Create_ForReceivingArea_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "RCV-AREA-03",
            name: "Receiving Inspection Area 03");

        storageLocation.Code.Should().Be("RCV-AREA-03");
        storageLocation.Name.Should().Contain("Receiving");
    }

    [Fact]
    public void Update_CanRenameExistingLocation()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "RACK-A1",
            name: "Rack A1");

        storageLocation.Update("RACK-A1", "Rack A1 - High-Velocity Storage");

        storageLocation.Code.Should().Be("RACK-A1");
        storageLocation.Name.Should().Contain("High-Velocity");
    }

    [Fact]
    public void Create_ForHazmatStorage_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "HAZMAT-RM-01",
            name: "Hazardous Materials Storage Room 01");

        storageLocation.Code.Should().Be("HAZMAT-RM-01");
        storageLocation.Name.Should().Contain("Hazardous");
    }

    [Fact]
    public void Create_ForReturnProcessing_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "RET-PROC-05",
            name: "Returns Processing Area 05");

        storageLocation.Code.Should().Be("RET-PROC-05");
        storageLocation.Name.Should().Contain("Returns");
    }

    [Fact]
    public void Create_ForCrossDockZone_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "XD-ZONE-A",
            name: "Cross-Dock Transfer Zone A");

        storageLocation.Code.Should().Be("XD-ZONE-A");
        storageLocation.Name.Should().Contain("Cross-Dock");
    }

    [Fact]
    public void Create_ForOverflowStorage_ShouldStoreCorrectly()
    {
        var storageLocation = StorageLocationData.CreateStorageLocation(
            code: "OVRFLW-B2",
            name: "Overflow Storage - Building 2");

        storageLocation.Code.Should().Be("OVRFLW-B2");
        storageLocation.Name.Should().Contain("Overflow");
    }
}