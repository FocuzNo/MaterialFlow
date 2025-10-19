using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Commands.Delete;

internal sealed class DeleteInventoryBalanceCommandHandler(
    IInventoryBalanceRepository inventoryBalanceRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteInventoryBalanceCommand, Result>
{
    public async Task<Result> Handle(
        DeleteInventoryBalanceCommand request,
        CancellationToken cancellationToken)
    {
        var inventoryBalance = await inventoryBalanceRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (inventoryBalance is null)
        {
            return Result.Failure(InventoryBalanceErrors.NotFound);
        }

        inventoryBalanceRepository.Delete(inventoryBalance);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
