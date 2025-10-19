namespace MaterialFlow.Application.PlannedProductionOrders.Queries.GetById;

public sealed record GetPlannedProductionOrderByIdQuery(Guid Id) : IRequest<Result<PlannedProductionOrderResponse>>;