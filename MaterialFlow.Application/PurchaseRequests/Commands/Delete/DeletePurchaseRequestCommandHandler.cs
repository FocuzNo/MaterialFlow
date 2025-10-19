using MaterialFlow.Domain.PurchaseRequests;

namespace MaterialFlow.Application.PurchaseRequests.Commands.Delete;

internal sealed class DeletePurchaseRequestCommandHandler(
    IPurchaseRequestRepository purchaseRequestRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeletePurchaseRequestCommand, Result>
{
    public async Task<Result> Handle(
        DeletePurchaseRequestCommand request,
        CancellationToken cancellationToken)
    {
        var purchaseRequest = await purchaseRequestRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (purchaseRequest is null)
        {
            return Result.Failure(PurchaseRequestErrors.NotFound);
        }

        purchaseRequestRepository.Delete(purchaseRequest);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}