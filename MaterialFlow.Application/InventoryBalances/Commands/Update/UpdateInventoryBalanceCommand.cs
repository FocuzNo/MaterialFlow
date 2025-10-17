namespace MaterialFlow.Application.InventoryBalances.Commands.Update;

public sealed record UpdateInventoryBalanceCommand(
    Guid Id,
    decimal OnHandAmount,
    string OnHandUnit,
    decimal ReservedAmount,
    string ReservedUnit,
    string? Batch) : IRequest<Result>;
