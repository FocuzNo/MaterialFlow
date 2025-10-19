namespace MaterialFlow.Application.SalesOrderDemands.Commands.Update;

public sealed record UpdateSalesOrderDemandCommand(
    Guid Id,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string UnitOfMeasure) : IRequest<Result>;