using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Queries.GetById;

internal sealed class GetInventoryBalanceByIdQueryHandler(IInventoryBalanceRepository inventoryBalanceRepository)
    : IRequestHandler<GetInventoryBalanceByIdQuery, Result<InventoryBalanceResponse>>
{
    public async Task<Result<InventoryBalanceResponse>> Handle(
        GetInventoryBalanceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var inventoryBalance = await inventoryBalanceRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (inventoryBalance is null)
        {
            return Result.Failure<InventoryBalanceResponse>(InventoryBalanceErrors.NotFound);
        }

        var response = new InventoryBalanceResponse(
            inventoryBalance.Id,
            inventoryBalance.MaterialId,
            inventoryBalance.SiteId,
            inventoryBalance.StorageLocationId,
            inventoryBalance.OnHand.Amount,
            inventoryBalance.OnHand.UnitOfMeasure.Value,
            inventoryBalance.Reserved.Amount,
            inventoryBalance.Reserved.UnitOfMeasure.Value,
            inventoryBalance.Batch);

        return Result.Success(response);
    }
}