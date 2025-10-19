using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Commands.Create;

internal sealed class CreateInventoryBalanceCommandHandler(
    IInventoryBalanceRepository inventoryBalanceRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateInventoryBalanceCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateInventoryBalanceCommand request,
        CancellationToken cancellationToken)
    {
        var inventoryBalance = InventoryBalance.Create(
            Guid.NewGuid(),
            request.MaterialId,
            request.SiteId,
            request.StorageLocationId,
            new Quantity(
                request.OnHandAmount,
                new UnitOfMeasure(request.OnHandUnitOfMeasure)),
            new Quantity(
                request.ReservedAmount,
                new UnitOfMeasure(request.ReservedUnitOfMeasure)),
            request.Batch);

        await inventoryBalanceRepository.AddAsync(
            inventoryBalance,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return inventoryBalance.Id;
    }
}