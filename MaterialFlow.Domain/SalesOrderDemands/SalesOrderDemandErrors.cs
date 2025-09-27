namespace MaterialFlow.Domain.SalesOrderDemands;

public static class SalesOrderDemandErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(SalesOrderDemand)}.{NotFound}",
        "The sales order demand with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(SalesOrderDemand)}.{InvalidUpdate}",
        "The sales order demand update is invalid");
}