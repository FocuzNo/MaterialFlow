namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Update;

public sealed record UpdatePlannedProductionOrderCommand(
    Guid Id,
    decimal Quantity,
    DateOnly StartDate,
    DateOnly EndDate,
    int OrderStatus) : IRequest<Result>;