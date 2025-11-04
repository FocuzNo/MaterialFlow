using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Materials.ValueObjects;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.Materials;

internal static class MaterialData
{
    public static Material CreateMaterial(
        Guid? id = null,
        MaterialNumber? materialNumber = null,
        string? description = null,
        UnitOfMeasure? unitOfMeasure = null,
        MaterialRequirementsPlanningType? materialRequirementsPlanningType = null,
        LotSizePolicy? lotSizePolicy = null,
        ProcurementType? procurementType = null,
        int? plannedDeliveryTimeInDays = null,
        Quantity? safetyStockQuantity = null) =>
        Material.Create(
            id ?? Guid.NewGuid(),
            materialNumber ?? new MaterialNumber("MAT-10001"),
            description ?? "Standard Component",
            unitOfMeasure ?? new UnitOfMeasure("Piece"),
            materialRequirementsPlanningType ?? MaterialRequirementsPlanningType.ClassicMrp,
            lotSizePolicy ?? LotSizePolicy.LotForLot,
            procurementType ?? ProcurementType.InHouse,
            plannedDeliveryTimeInDays ?? 5,
            safetyStockQuantity ?? new Quantity(50, new UnitOfMeasure("Piece")));
}