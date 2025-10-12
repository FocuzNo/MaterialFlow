namespace MaterialFlow.Application.Materials.Commands.Update;

public sealed record UpdateMaterialCommand(
    Guid Id,
    string MaterialNumber,
    string Description,
    string UnitOfMeasure,
    int MaterialRequirementsPlanningType,
    int LotSizePolicy,
    int ProcurementType,
    int PlannedDeliveryTimeInDays,
    decimal SafetyStockAmount,
    string SafetyStockUnitOfMeasure) : IRequest<Result>;
