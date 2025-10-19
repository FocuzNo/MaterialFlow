namespace MaterialFlow.Application.PurchaseRequests.Commands.Update;

public sealed record UpdatePurchaseRequestCommand(
    Guid Id,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    DateOnly RequestedDeliveryDate,
    string? PurchasingGroup,
    int OrderStatus) : IRequest<Result>;