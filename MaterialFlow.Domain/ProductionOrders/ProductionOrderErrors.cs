namespace MaterialFlow.Domain.ProductionOrders;

public static class ProductionOrderErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(ProductionOrder)}.{NotFound}",
        "The production order with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(ProductionOrder)}.{InvalidUpdate}",
        "The production order update is invalid");
}