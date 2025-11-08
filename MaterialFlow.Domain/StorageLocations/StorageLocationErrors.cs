namespace MaterialFlow.Domain.StorageLocations;

public static class StorageLocationErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(StorageLocation)}.{NotFound}",
        "The storage location with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(StorageLocation)}.{InvalidUpdate}",
        "The storage location update is invalid");

    public static readonly Error AlreadyExists = new(
        $"{nameof(StorageLocation)}.{AlreadyExists}",
        "Storage location with the specified code already exists.");
}