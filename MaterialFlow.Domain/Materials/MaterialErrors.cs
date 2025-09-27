namespace MaterialFlow.Domain.Materials;

public static class MaterialErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(Material)}.{NotFound}",
        "The material with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(Material)}.{InvalidUpdate}",
        "The material update is invalid");
}