namespace MaterialFlow.Domain.InventoryBalances;

public static class InventoryBalanceErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(InventoryBalance)}.{NotFound}",
        "The inventory balance with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(InventoryBalance)}.{InvalidUpdate}",
        "The inventory balance update is invalid");
}