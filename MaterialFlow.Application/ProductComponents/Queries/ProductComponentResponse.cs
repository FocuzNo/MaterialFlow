namespace MaterialFlow.Application.ProductComponents.Queries;

public sealed record ProductComponentResponse(
    Guid Id,
    Guid ProductStructureId,
    Guid MaterialId,
    string UnitOfMeasure,
    decimal QuantityPerAmount,
    string QuantityPerUnitOfMeasure,
    decimal? ScrapPercentage);