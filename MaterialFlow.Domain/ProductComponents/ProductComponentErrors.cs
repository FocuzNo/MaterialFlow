namespace MaterialFlow.Domain.ProductComponents;

public static class ProductComponentErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(ProductComponent)}.{NotFound}",
        "The product component with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(ProductComponent)}.{InvalidUpdate}",
        "The product component update is invalid");
}