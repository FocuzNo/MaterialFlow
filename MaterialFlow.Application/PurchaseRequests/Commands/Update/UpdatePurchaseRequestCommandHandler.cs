using MaterialFlow.Domain.PurchaseRequests;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Application.PurchaseRequests.Commands.Update;

internal sealed class UpdatePurchaseRequestCommandHandler(
    IPurchaseRequestRepository purchaseRequestRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePurchaseRequestCommand, Result>
{
    public async Task<Result> Handle(
        UpdatePurchaseRequestCommand request,
        CancellationToken cancellationToken)
    {
        var purchaseRequest = await purchaseRequestRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (purchaseRequest is null)
        {
            return Result.Failure(PurchaseRequestErrors.NotFound);
        }

        purchaseRequest.Update(
            new Quantity(
                request.QuantityAmount,
                new UnitOfMeasure(request.QuantityUnitOfMeasure)),
            request.RequestedDeliveryDate,
            request.PurchasingGroup,
            OrderStatus.FromValue(request.OrderStatus));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}