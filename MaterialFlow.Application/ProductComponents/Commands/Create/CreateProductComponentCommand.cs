namespace MaterialFlow.Application.ProductComponents.Commands.Create;

public sealed record CreateProductComponentCommand(
    Guid ProductStructureId,
    Guid MaterialId,
    string UnitOfMeasure,
    decimal QuantityPerAmount,
    string QuantityPerUnitOfMeasure,
    decimal? ScrapPercentage) : IRequest<Guid>;