namespace MaterialFlow.Domain.Sites;

public static class StorageLocationErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(StorageLocation)}.{NotFound}",
        "The storage location with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(StorageLocation)}.{InvalidUpdate}",
        "The storage location update is invalid");
}