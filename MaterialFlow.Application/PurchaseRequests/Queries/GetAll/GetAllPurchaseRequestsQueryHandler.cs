using MaterialFlow.Domain.PurchaseRequests;

namespace MaterialFlow.Application.PurchaseRequests.Queries.GetAll;

internal sealed class GetAllPurchaseRequestsQueryHandler(IPurchaseRequestRepository purchaseRequestRepository)
    : IRequestHandler<GetAllPurchaseRequestsQuery, Result<IReadOnlyCollection<PurchaseRequestResponse>>>
{
    public async Task<Result<IReadOnlyCollection<PurchaseRequestResponse>>> Handle(
        GetAllPurchaseRequestsQuery request,
        CancellationToken cancellationToken)
    {
        var purchaseRequests = await purchaseRequestRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<PurchaseRequestResponse>)[.. purchaseRequests
            .Select(x => new PurchaseRequestResponse(
                x.Id,
                x.MaterialId,
                x.SiteId,
                x.PlanningRunId,
                x.Quantity.Amount,
                x.Quantity.UnitOfMeasure.Value,
                x.UnitOfMeasure.Value,
                x.RequestedDeliveryDate,
                x.PurchasingGroup,
                x.OrderStatus.Name)
            )]);
    }
}