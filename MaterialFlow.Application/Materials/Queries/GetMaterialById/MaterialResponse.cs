namespace MaterialFlow.Application.Materials.Queries.GetMaterialById;

public sealed record MaterialResponse(
    Guid Id,
    string MaterialNumber,
    string Description,
    string BaseUnitOfMeasure,
    string MRPType,
    string LotSizePolicy,
    string ProcurementType,
    int PlannedDeliveryTimeInDays,
    decimal SafetyStockQuantity,
    bool IsActive);