using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Application.Materials.Commands.Create;

public sealed record CreateMaterialCommand(
    Guid Id,
    string MaterialNumber,
    string Description,
    UnitOfMeasure BaseUnitOfMeasure,
    MaterialRequirementsPlanningType MRPType,
    LotSizePolicy LotSizePolicy,
    ProcurementType ProcurementType,
    int PlannedDeliveryTimeInDays,
    Quantity SafetyStockQuantity) : IRequest<Guid>;
