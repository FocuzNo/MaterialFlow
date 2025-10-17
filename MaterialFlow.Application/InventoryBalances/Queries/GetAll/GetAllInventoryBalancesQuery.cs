namespace MaterialFlow.Application.InventoryBalances.Queries.GetAll;

public sealed record GetAllInventoryBalancesQuery()
    : IRequest<Result<IReadOnlyCollection<InventoryBalanceResponse>>>;