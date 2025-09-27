using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Application.Abstractions.Materials.Commands.Create;

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
