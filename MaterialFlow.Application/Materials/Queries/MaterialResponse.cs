namespace MaterialFlow.Application.Materials.Queries;

public sealed record MaterialResponse(
    Guid Id,
    string MaterialNumber,
    string Description,
    string UnitOfMeasure,
    string MRPType,
    string LotSizePolicy,
    string ProcurementType,
    int PlannedDeliveryTimeInDays,
    decimal SafetyStockQuantity,
    bool IsActive);