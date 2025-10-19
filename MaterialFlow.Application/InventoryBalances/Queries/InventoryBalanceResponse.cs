namespace MaterialFlow.Application.InventoryBalances.Queries;

public sealed record InventoryBalanceResponse(
    Guid Id,
    Guid MaterialId,
    Guid SiteId,
    Guid? StorageLocationId,
    decimal OnHandAmount,
    string OnHandUnitOfMeasure,
    decimal ReservedAmount,
    string ReservedUnitOfMeasure,
    string? Batch);