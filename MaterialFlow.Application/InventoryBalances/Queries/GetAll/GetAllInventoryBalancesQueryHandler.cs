using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Queries.GetAll;

internal sealed class GetAllInventoryBalancesQueryHandler(IInventoryBalanceRepository inventoryBalanceRepository)
    : IRequestHandler<GetAllInventoryBalancesQuery, Result<IReadOnlyCollection<InventoryBalanceResponse>>>
{
    public async Task<Result<IReadOnlyCollection<InventoryBalanceResponse>>> Handle(
        GetAllInventoryBalancesQuery request,
        CancellationToken cancellationToken)
    {
        var inventoryBalances = await inventoryBalanceRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<InventoryBalanceResponse>)[.. inventoryBalances
            .Select(x => new InventoryBalanceResponse(
                x.Id,
                x.MaterialId,
                x.SiteId,
                x.StorageLocationId,
                x.OnHand.Amount,
                x.OnHand.UnitOfMeasure.Value,
                x.Reserved.Amount,
                x.Reserved.UnitOfMeasure.Value,
                x.Batch)
            )]);
    }
}