namespace MaterialFlow.Application.ProductionOrders.Queries.GetById;

public sealed record GetProductionOrderByIdQuery(Guid Id) : IRequest<Result<ProductionOrderResponse>>;