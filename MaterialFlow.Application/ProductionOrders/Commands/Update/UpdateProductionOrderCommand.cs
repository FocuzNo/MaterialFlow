namespace MaterialFlow.Application.ProductionOrders.Commands.Update;

public sealed record UpdateProductionOrderCommand(
    Guid Id,
    decimal QuantityToProduceAmount,
    string QuantityToProduceUnitOfMeasure,
    DateOnly ScheduledStartDate,
    DateOnly ScheduledEndDate,
    int OrderStatus) : IRequest<Result>;