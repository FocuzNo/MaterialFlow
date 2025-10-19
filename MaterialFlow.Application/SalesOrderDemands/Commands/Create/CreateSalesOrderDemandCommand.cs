namespace MaterialFlow.Application.SalesOrderDemands.Commands.Create;

public sealed record CreateSalesOrderDemandCommand(
    Guid MaterialId,
    Guid SiteId,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string UnitOfMeasure,
    string SourceDocumentType,
    string SourceDocumentNumber,
    string SourceDocumentItemNumber) : IRequest<Guid>;