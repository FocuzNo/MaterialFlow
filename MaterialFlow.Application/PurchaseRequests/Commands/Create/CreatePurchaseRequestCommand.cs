namespace MaterialFlow.Application.PurchaseRequests.Commands.Create;

public sealed record CreatePurchaseRequestCommand(
    Guid MaterialId,
    Guid SiteId,
    Guid? PlanningRunId,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string UnitOfMeasure,
    DateOnly RequestedDeliveryDate,
    string? PurchasingGroup,
    int OrderStatus) : IRequest<Guid>;