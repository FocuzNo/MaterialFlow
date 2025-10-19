namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Create;

public sealed record CreatePlannedProductionOrderCommand(
    Guid MaterialId,
    Guid SiteId,
    Guid? PlanningRunId,
    decimal Quantity,
    string UnitOfMeasure,
    DateOnly StartDate,
    DateOnly EndDate,
    int OrderStatus) : IRequest<Guid>;