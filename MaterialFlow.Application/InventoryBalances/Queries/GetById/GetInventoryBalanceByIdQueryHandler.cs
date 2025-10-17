using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Queries.GetById;

internal sealed class GetInventoryBalanceByIdQueryHandler(
    IInventoryBalanceRepository repository)
    : IRequestHandler<GetInventoryBalanceByIdQuery, Result<InventoryBalanceResponse>>
{
    public async Task<Result<InventoryBalanceResponse>> Handle(GetInventoryBalanceByIdQuery request, CancellationToken cancellationToken)
    {
        var balance = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (balance is null)
        {
            return Result.Failure<InventoryBalanceResponse>(InventoryBalanceErrors.NotFound);
        }

        var response = new InventoryBalanceResponse(
            balance.Id,
            balance.MaterialId,
            balance.Material.MaterialNumber.Value,
            balance.SiteId,
            balance.Site.Name,
            balance.StorageLocationId,
            balance.StorageLocation?.Name,
            balance.OnHand.Amount,
            balance.OnHand.UnitOfMeasure.Value,
            balance.Reserved.Amount,
            balance.Reserved.UnitOfMeasure.Value,
            balance.Batch);

        return Result.Success(response);
    }
}
