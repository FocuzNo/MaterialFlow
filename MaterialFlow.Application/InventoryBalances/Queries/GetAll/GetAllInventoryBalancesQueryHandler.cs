using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Queries.GetAll;

internal sealed class GetAllInventoryBalancesQueryHandler(
    IInventoryBalanceRepository repository)
    : IRequestHandler<GetAllInventoryBalancesQuery, Result<IReadOnlyCollection<InventoryBalanceResponse>>>
{
    public async Task<Result<IReadOnlyCollection<InventoryBalanceResponse>>> Handle(GetAllInventoryBalancesQuery request, CancellationToken cancellationToken)
    {
        var balances = await repository.GetAllAsync(cancellationToken);

        var response = balances.Select(x => new InventoryBalanceResponse(
            x.Id,
            x.MaterialId,
            x.Material.MaterialNumber.Value,
            x.SiteId,
            x.Site.Name,
            x.StorageLocationId,
            x.StorageLocation?.Name,
            x.OnHand.Amount,
            x.OnHand.UnitOfMeasure.Value,
            x.Reserved.Amount,
            x.Reserved.UnitOfMeasure.Value,
            x.Batch)).ToList();

        return Result.Success<IReadOnlyCollection<InventoryBalanceResponse>>(response);
    }
}
