namespace MaterialFlow.Application.ProductionOrders.Queries;

public sealed record ProductionOrderResponse(
    Guid Id,
    Guid MaterialId,
    Guid SiteId,
    Guid? PlannedProductionOrderId,
    decimal QuantityToProduceAmount,
    string QuantityToProduceUnitOfMeasure,
    string UnitOfMeasure,
    DateOnly ScheduledStartDate,
    DateOnly ScheduledEndDate,
    string OrderStatus);