namespace MaterialFlow.Application.ProductionOrders.Commands.Create;

public sealed record CreateProductionOrderCommand(
    Guid MaterialId,
    Guid SiteId,
    Guid? PlannedProductionOrderId,
    decimal QuantityToProduceAmount,
    string QuantityToProduceUnitOfMeasure,
    string UnitOfMeasure,
    DateOnly ScheduledStartDate,
    DateOnly ScheduledEndDate,
    int OrderStatus) : IRequest<Guid>;