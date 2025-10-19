namespace MaterialFlow.Application.SalesOrderDemands.Queries.GetById;

public sealed record GetSalesOrderDemandByIdQuery(Guid Id) : IRequest<Result<SalesOrderDemandResponse>>;