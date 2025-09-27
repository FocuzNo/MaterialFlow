using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Materials.Events;
using MaterialFlow.Domain.Materials.ValueObjects;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.Materials;

public sealed class Material : Entity
{
    private Material() { }

    public MaterialNumber MaterialNumber { get; private set; }

    public string Description { get; private set; }

    public UnitOfMeasure BaseUnitOfMeasure { get; private set; }

    public MaterialRequirementsPlanningType MaterialRequirementsPlanningType { get; private set; }

    public LotSizePolicy LotSizePolicy { get; private set; }

    public ProcurementType ProcurementType { get; private set; }

    public int PlannedDeliveryTimeInDays { get; private set; }

    public Quantity SafetyStockQuantity { get; private set; }

    public bool IsActive { get; private set; } = true;

    public static Material Create(
        Guid id,
        MaterialNumber materialNumber,
        string description,
        UnitOfMeasure baseUnitOfMeasure,
        MaterialRequirementsPlanningType materialRequirementsPlanningType,
        LotSizePolicy lotSizePolicy,
        ProcurementType procurementType,
        int plannedDeliveryTimeInDays,
        Quantity safetyStockQuantity)
    {
        var material = new Material
        {
            Id = id,
            MaterialNumber = materialNumber,
            Description = description,
            BaseUnitOfMeasure = baseUnitOfMeasure,
            MaterialRequirementsPlanningType = materialRequirementsPlanningType,
            LotSizePolicy = lotSizePolicy,
            ProcurementType = procurementType,
            PlannedDeliveryTimeInDays = plannedDeliveryTimeInDays,
            SafetyStockQuantity = safetyStockQuantity,
            IsActive = true
        };

        material.RaiseDomainEvent(new MaterialCreatedDomainEvent(material.Id));

        return material;
    }

    public void Update(
        MaterialNumber materialNumber,
        string description,
        UnitOfMeasure baseUnitOfMeasure,
        MaterialRequirementsPlanningType materialRequirementsPlanningType,
        LotSizePolicy lotSizePolicy,
        ProcurementType procurementType,
        int plannedDeliveryTimeInDays,
        Quantity safetyStockQuantity)
    {
        MaterialNumber = materialNumber;
        Description = description;
        BaseUnitOfMeasure = baseUnitOfMeasure;
        MaterialRequirementsPlanningType = materialRequirementsPlanningType;
        LotSizePolicy = lotSizePolicy;
        ProcurementType = procurementType;
        PlannedDeliveryTimeInDays = plannedDeliveryTimeInDays;
        SafetyStockQuantity = safetyStockQuantity;

        RaiseDomainEvent(new MaterialUpdatedDomainEvent(Id));
    }

    public void Deactivate()
    {
        if (!IsActive)
        {
            return;
        }

        IsActive = false;

        RaiseDomainEvent(new MaterialDeactivatedDomainEvent(Id));
    }
}
