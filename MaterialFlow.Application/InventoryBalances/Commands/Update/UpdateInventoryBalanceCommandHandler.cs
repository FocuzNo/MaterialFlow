using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Commands.Update;

internal sealed class UpdateInventoryBalanceCommandHandler(
    IInventoryBalanceRepository inventoryBalanceRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateInventoryBalanceCommand, Result>
{
    public async Task<Result> Handle(
        UpdateInventoryBalanceCommand request,
        CancellationToken cancellationToken)
    {
        var inventoryBalance = await inventoryBalanceRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (inventoryBalance is null)
        {
            return Result.Failure(InventoryBalanceErrors.NotFound);
        }

        inventoryBalance.Update(
            new Quantity(
                request.OnHandAmount,
                new UnitOfMeasure(request.OnHandUnitOfMeasure)),
            new Quantity(
                request.ReservedAmount,
                new UnitOfMeasure(request.ReservedUnitOfMeasure)),
            request.Batch);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}