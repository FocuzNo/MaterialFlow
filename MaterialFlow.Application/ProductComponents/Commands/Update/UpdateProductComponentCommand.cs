namespace MaterialFlow.Application.ProductComponents.Commands.Update;

public sealed record UpdateProductComponentCommand(
    Guid Id,
    string UnitOfMeasure,
    decimal QuantityPerAmount,
    string QuantityPerUnitOfMeasure,
    decimal? ScrapPercentage) : IRequest<Result>;