namespace MaterialFlow.Application.PlannedProductionOrders.Queries.GetAll;

public sealed record GetAllPlannedProductionOrdersQuery : IRequest<Result<IReadOnlyCollection<PlannedProductionOrderResponse>>>;