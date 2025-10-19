using MaterialFlow.Domain.PurchaseRequests;

namespace MaterialFlow.Application.PurchaseRequests.Commands.Create;

internal sealed class CreatePurchaseRequestCommandHandler(
    IPurchaseRequestRepository purchaseRequestRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePurchaseRequestCommand, Guid>
{
    public async Task<Guid> Handle(
        CreatePurchaseRequestCommand request,
        CancellationToken cancellationToken)
    {
        var purchaseRequest = PurchaseRequest.Create(
            Guid.NewGuid(),
            request.MaterialId,
            request.SiteId,
            request.PlanningRunId,
            new Quantity(
                request.QuantityAmount,
                new UnitOfMeasure(request.QuantityUnitOfMeasure)),
            new UnitOfMeasure(request.UnitOfMeasure),
            request.RequestedDeliveryDate,
            request.PurchasingGroup,
            OrderStatus.FromValue(request.OrderStatus));

        await purchaseRequestRepository.AddAsync(
            purchaseRequest,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return purchaseRequest.Id;
    }
}