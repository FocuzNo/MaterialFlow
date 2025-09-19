using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Materials.ValueObjects;

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

    public decimal SafetyStockQuantity { get; private set; }

    public static Material Create(
        Guid id,
        MaterialNumber materialNumber,
        string description,
        UnitOfMeasure baseUnitOfMeasure,
        MaterialRequirementsPlanningType materialRequirementsPlanningType,
        LotSizePolicy lotSizePolicy,
        ProcurementType procurementType,
        int plannedDeliveryTimeInDays,
        decimal safetyStockQuantity)
        => new()
        {
            Id = id,
            MaterialNumber = materialNumber,
            Description = description,
            BaseUnitOfMeasure = baseUnitOfMeasure,
            MaterialRequirementsPlanningType = materialRequirementsPlanningType,
            LotSizePolicy = lotSizePolicy,
            ProcurementType = procurementType,
            PlannedDeliveryTimeInDays = plannedDeliveryTimeInDays,
            SafetyStockQuantity = safetyStockQuantity
        };

    public void Update(
        MaterialNumber materialNumber,
        string description,
        UnitOfMeasure baseUnitOfMeasure,
        MaterialRequirementsPlanningType materialRequirementsPlanningType,
        LotSizePolicy lotSizePolicy,
        ProcurementType procurementType,
        int plannedDeliveryTimeInDays,
        decimal safetyStockQuantity)
    {
        MaterialNumber = materialNumber;
        Description = description;
        BaseUnitOfMeasure = baseUnitOfMeasure;
        MaterialRequirementsPlanningType = materialRequirementsPlanningType;
        LotSizePolicy = lotSizePolicy;
        ProcurementType = procurementType;
        PlannedDeliveryTimeInDays = plannedDeliveryTimeInDays;
        SafetyStockQuantity = safetyStockQuantity;
    }
}