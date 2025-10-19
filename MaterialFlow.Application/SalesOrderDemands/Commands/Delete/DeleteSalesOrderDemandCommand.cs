namespace MaterialFlow.Application.SalesOrderDemands.Commands.Delete;

public sealed record DeleteSalesOrderDemandCommand(Guid Id) : IRequest<Result>;