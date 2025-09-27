namespace MaterialFlow.Domain.ProductStructures;

public static class ProductStructureErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(ProductStructure)}.{NotFound}",
        "The product structure with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(ProductStructure)}.{InvalidUpdate}",
        "The product structure update is invalid");
}