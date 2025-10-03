using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Application.Materials.Commands.Update;

public sealed record UpdateMaterialCommand(
    Guid Id,
    string MaterialNumber,
    string Description,
    UnitOfMeasure BaseUnitOfMeasure,
    MaterialRequirementsPlanningType MRPType,
    LotSizePolicy LotSizePolicy,
    ProcurementType ProcurementType,
    int PlannedDeliveryTimeInDays,
    Quantity SafetyStockQuantity) : IRequest<Result>;