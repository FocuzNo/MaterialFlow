using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Application.Abstractions.Materials.Commands.Update;

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