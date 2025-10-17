namespace MaterialFlow.Application.InventoryBalances.Queries.GetById;

public sealed record GetInventoryBalanceByIdQuery(Guid Id)
    : IRequest<Result<InventoryBalanceResponse>>;