namespace MaterialFlow.Application.InventoryBalances.Commands.Update;

public sealed record UpdateInventoryBalanceCommand(
    Guid Id,
    decimal OnHandAmount,
    string OnHandUnitOfMeasure,
    decimal ReservedAmount,
    string ReservedUnitOfMeasure,
    string? Batch) : IRequest<Result>;