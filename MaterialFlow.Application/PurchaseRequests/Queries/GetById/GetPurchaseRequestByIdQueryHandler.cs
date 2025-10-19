using MaterialFlow.Domain.PurchaseRequests;

namespace MaterialFlow.Application.PurchaseRequests.Queries.GetById;

internal sealed class GetPurchaseRequestByIdQueryHandler(IPurchaseRequestRepository purchaseRequestRepository)
    : IRequestHandler<GetPurchaseRequestByIdQuery, Result<PurchaseRequestResponse>>
{
    public async Task<Result<PurchaseRequestResponse>> Handle(
        GetPurchaseRequestByIdQuery request,
        CancellationToken cancellationToken)
    {
        var purchaseRequest = await purchaseRequestRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (purchaseRequest is null)
        {
            return Result.Failure<PurchaseRequestResponse>(PurchaseRequestErrors.NotFound);
        }

        var response = new PurchaseRequestResponse(
            purchaseRequest.Id,
            purchaseRequest.MaterialId,
            purchaseRequest.SiteId,
            purchaseRequest.PlanningRunId,
            purchaseRequest.Quantity.Amount,
            purchaseRequest.Quantity.UnitOfMeasure.Value,
            purchaseRequest.UnitOfMeasure.Value,
            purchaseRequest.RequestedDeliveryDate,
            purchaseRequest.PurchasingGroup,
            purchaseRequest.OrderStatus.Name);

        return Result.Success(response);
    }
}