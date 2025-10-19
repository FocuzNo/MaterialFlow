namespace MaterialFlow.Application.InventoryBalances.Commands.Create;

public sealed record CreateInventoryBalanceCommand(
    Guid MaterialId,
    Guid SiteId,
    Guid? StorageLocationId,
    decimal OnHandAmount,
    string OnHandUnitOfMeasure,
    decimal ReservedAmount,
    string ReservedUnitOfMeasure,
    string? Batch) : IRequest<Guid>;