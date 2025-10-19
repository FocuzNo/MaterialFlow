namespace MaterialFlow.Application.SalesOrderDemands.Queries.GetAll;

public sealed record GetAllSalesOrderDemandsQuery : IRequest<Result<IReadOnlyCollection<SalesOrderDemandResponse>>>;