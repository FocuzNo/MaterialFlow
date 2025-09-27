namespace MaterialFlow.Domain.PlannedProductionOrders;

public static class PlannedProductionOrderErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(PlannedProductionOrder)}.{NotFound}",
        "The planned production order with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(PlannedProductionOrder)}.{InvalidUpdate}",
        "The planned production order update is invalid");
}