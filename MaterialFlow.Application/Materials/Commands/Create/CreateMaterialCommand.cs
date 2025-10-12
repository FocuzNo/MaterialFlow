namespace MaterialFlow.Application.Materials.Commands.Create;

public sealed record CreateMaterialCommand(
    string MaterialNumber,
    string Description,
    string UnitOfMeasure,
    int MaterialRequirementsPlanningType,
    int LotSizePolicy,
    int ProcurementType,
    int PlannedDeliveryTimeInDays,
    decimal SafetyStockAmount,
    string SafetyStockUnitOfMeasure) : IRequest<Guid>;
