namespace MaterialFlow.Application.PurchaseRequests.Queries;

public sealed record PurchaseRequestResponse(
    Guid Id,
    Guid MaterialId,
    Guid SiteId,
    Guid? PlanningRunId,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string UnitOfMeasure,
    DateOnly RequestedDeliveryDate,
    string? PurchasingGroup,
    string OrderStatus);