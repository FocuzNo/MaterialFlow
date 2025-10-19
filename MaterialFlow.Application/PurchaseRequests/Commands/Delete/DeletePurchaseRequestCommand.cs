namespace MaterialFlow.Application.PurchaseRequests.Commands.Delete;

public sealed record DeletePurchaseRequestCommand(Guid Id) : IRequest<Result>;