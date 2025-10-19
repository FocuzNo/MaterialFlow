namespace MaterialFlow.Application.PurchaseRequests.Queries.GetAll;

public sealed record GetAllPurchaseRequestsQuery : IRequest<Result<IReadOnlyCollection<PurchaseRequestResponse>>>;