namespace MaterialFlow.Application.ProductionOrders.Queries.GetAll;

public sealed record GetAllProductionOrdersQuery : IRequest<Result<IReadOnlyCollection<ProductionOrderResponse>>>;