namespace MaterialFlow.Domain.PurchaseRequests;

public static class PurchaseRequestErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(PurchaseRequest)}.{NotFound}",
        "The purchase request with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(PurchaseRequest)}.{InvalidUpdate}",
        "The purchase request update is invalid");
}