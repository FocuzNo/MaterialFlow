namespace MaterialFlow.Application.InventoryBalances.Commands.Delete;

public sealed record DeleteInventoryBalanceCommand(Guid Id) : IRequest<Result>;