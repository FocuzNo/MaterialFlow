namespace MaterialFlow.Application.SalesOrderDemands.Queries;

public sealed record SalesOrderDemandResponse(
    Guid Id,
    Guid MaterialId,
    Guid SiteId,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string UnitOfMeasure,
    string SourceDocumentType,
    string SourceDocumentNumber,
    string SourceDocumentItemNumber);