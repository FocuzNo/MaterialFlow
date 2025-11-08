using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Domain.UnitTests.StorageLocations;

internal static class StorageLocationData
{
    public static StorageLocation CreateStorageLocation(
        Guid? id = null,
        Guid? siteId = null,
        string? code = null,
        string? name = null) =>
        StorageLocation.Create(
            id ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            code ?? "WH-A-01",
            name ?? "Warehouse A - Aisle 01");
}