namespace MaterialFlow.Application.InventoryBalances.Queries;

public sealed record InventoryBalanceResponse(
    Guid Id,
    Guid MaterialId,
    string MaterialNumber,
    Guid SiteId,
    string SiteName,
    Guid? StorageLocationId,
    string? StorageLocationName,
    decimal OnHandAmount,
    string OnHandUnit,
    decimal ReservedAmount,
    string ReservedUnit,
    string? Batch);