namespace MaterialFlow.Application.PlannedProductionOrders.Queries;

public sealed record PlannedProductionOrderResponse(
    Guid Id,
    Guid MaterialId,
    Guid SiteId,
    Guid? PlanningRunId,
    decimal Quantity,
    string UnitOfMeasure,
    DateOnly StartDate,
    DateOnly EndDate,
    string OrderStatus);