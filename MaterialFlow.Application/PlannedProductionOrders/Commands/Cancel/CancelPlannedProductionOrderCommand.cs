namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Cancel;

public sealed record CancelPlannedProductionOrderCommand(Guid Id) : IRequest<Result>;