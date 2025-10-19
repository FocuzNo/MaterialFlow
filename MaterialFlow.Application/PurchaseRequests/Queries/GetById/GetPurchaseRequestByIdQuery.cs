namespace MaterialFlow.Application.PurchaseRequests.Queries.GetById;

public sealed record GetPurchaseRequestByIdQuery(Guid Id) : IRequest<Result<PurchaseRequestResponse>>;