using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Materials.Events;
using MaterialFlow.Domain.Materials.ValueObjects;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.Materials;

public sealed class MaterialTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeMaterial_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var materialNumber = new MaterialNumber("RM-45782");
        var description = "High-Grade Steel Alloy Sheet";
        var unitOfMeasure = new UnitOfMeasure("Kilogram");
        var mrpType = MaterialRequirementsPlanningType.ConsumptionBased;
        var lotSizePolicy = LotSizePolicy.FixedLot;
        var procurementType = ProcurementType.External;
        var plannedDeliveryTime = 14;
        var safetyStock = new Quantity(500, new UnitOfMeasure("Kilogram"));

        var material = Material.Create(
            id,
            materialNumber,
            description,
            unitOfMeasure,
            mrpType,
            lotSizePolicy,
            procurementType,
            plannedDeliveryTime,
            safetyStock);

        material.Id.Should().Be(id);
        material.MaterialNumber.Should().Be(materialNumber);
        material.Description.Should().Be(description);
        material.UnitOfMeasure.Should().Be(unitOfMeasure);
        material.MaterialRequirementsPlanningType.Should().Be(mrpType);
        material.LotSizePolicy.Should().Be(lotSizePolicy);
        material.ProcurementType.Should().Be(procurementType);
        material.PlannedDeliveryTimeInDays.Should().Be(plannedDeliveryTime);
        material.SafetyStockQuantity.Should().Be(safetyStock);
        material.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Create_ShouldRaise_MaterialCreatedDomainEvent()
    {
        var material = MaterialData.CreateMaterial();

        AssertDomainEventWasPublished<MaterialCreatedDomainEvent>(material);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var material = MaterialData.CreateMaterial();
        var newMaterialNumber = new MaterialNumber("FG-98765");
        var newDescription = "Premium Electronic Component Assembly";
        var newUnitOfMeasure = new UnitOfMeasure("Piece");
        var newMrpType = MaterialRequirementsPlanningType.ClassicMrp;
        var newLotSizePolicy = LotSizePolicy.Weekly;
        var newProcurementType = ProcurementType.Mixed;
        var newPlannedDeliveryTime = 21;
        var newSafetyStock = new Quantity(200, new UnitOfMeasure("Piece"));

        material.Update(
            newMaterialNumber,
            newDescription,
            newUnitOfMeasure,
            newMrpType,
            newLotSizePolicy,
            newProcurementType,
            newPlannedDeliveryTime,
            newSafetyStock);

        material.MaterialNumber.Should().Be(newMaterialNumber);
        material.Description.Should().Be(newDescription);
        material.UnitOfMeasure.Should().Be(newUnitOfMeasure);
        material.MaterialRequirementsPlanningType.Should().Be(newMrpType);
        material.LotSizePolicy.Should().Be(newLotSizePolicy);
        material.ProcurementType.Should().Be(newProcurementType);
        material.PlannedDeliveryTimeInDays.Should().Be(newPlannedDeliveryTime);
        material.SafetyStockQuantity.Should().Be(newSafetyStock);
    }

    [Fact]
    public void Update_ShouldRaise_MaterialUpdatedDomainEvent()
    {
        var material = MaterialData.CreateMaterial();
        material.ClearDomainEvents();

        material.Update(
            new MaterialNumber("SFG-33221"),
            "Semi-Finished Plastic Housing Unit",
            new UnitOfMeasure("Box"),
            MaterialRequirementsPlanningType.ConsumptionBased,
            LotSizePolicy.LotForLot,
            ProcurementType.InHouse,
            7,
            new Quantity(100, new UnitOfMeasure("Box")));

        AssertDomainEventWasPublished<MaterialUpdatedDomainEvent>(material);
    }

    [Fact]
    public void Update_ShouldNotModify_IsActiveProperty()
    {
        var material = MaterialData.CreateMaterial();
        var originalIsActive = material.IsActive;

        material.Update(
            new MaterialNumber("CHEM-7890"),
            "Industrial Chemical Compound XR-47",
            new UnitOfMeasure("Liter"),
            MaterialRequirementsPlanningType.ClassicMrp,
            LotSizePolicy.FixedLot,
            ProcurementType.External,
            30,
            new Quantity(1000, new UnitOfMeasure("Liter")));

        material.IsActive.Should().Be(originalIsActive);
    }

    [Fact]
    public void Deactivate_ShouldSetIsActiveToFalse()
    {
        var material = MaterialData.CreateMaterial();

        material.Deactivate();

        material.IsActive.Should().BeFalse();
    }

    [Fact]
    public void Deactivate_ShouldRaise_MaterialDeactivatedDomainEvent()
    {
        var material = MaterialData.CreateMaterial();
        material.ClearDomainEvents();

        material.Deactivate();

        AssertDomainEventWasPublished<MaterialDeactivatedDomainEvent>(material);
    }

    [Fact]
    public void Deactivate_WhenAlreadyInactive_ShouldNotRaiseDomainEvent()
    {
        var material = MaterialData.CreateMaterial();
        material.Deactivate();
        material.ClearDomainEvents();

        material.Deactivate();

        material.GetDomainEvents().Should().BeEmpty();
    }

    [Fact]
    public void Deactivate_WhenCalledMultipleTimes_ShouldBeIdempotent()
    {
        var material = MaterialData.CreateMaterial();

        material.Deactivate();
        material.Deactivate();
        material.Deactivate();

        material.IsActive.Should().BeFalse();
    }
}