namespace MaterialFlow.Application.ProductStructures.Commands.AddComponent;

public sealed record AddProductComponentCommand(
    Guid ProductStructureId,
    Guid ComponentMaterialId,
    string UnitOfMeasure,
    decimal QuantityPerAmount,
    string QuantityPerUnitOfMeasure,
    decimal? ScrapPercentage) : IRequest<Result<Guid>>;