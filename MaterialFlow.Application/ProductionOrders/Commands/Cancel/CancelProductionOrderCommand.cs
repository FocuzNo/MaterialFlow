namespace MaterialFlow.Application.ProductionOrders.Commands.Cancel;

public sealed record CancelProductionOrderCommand(Guid Id) : IRequest<Result>;