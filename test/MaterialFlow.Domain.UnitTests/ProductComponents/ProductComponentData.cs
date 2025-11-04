using MaterialFlow.Domain.ProductComponents;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ProductComponents;

internal static class ProductComponentData
{
    public static ProductComponent CreateComponent(
        Guid? id = null,
        Guid? productStructureId = null,
        Guid? materialId = null,
        UnitOfMeasure? unitOfMeasure = null,
        Quantity? quantityPer = null,
        decimal? scrapPercentage = null) =>
        ProductComponent.Create(
            id ?? Guid.NewGuid(),
            productStructureId ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            unitOfMeasure ?? new UnitOfMeasure("Piece"),
            quantityPer ?? new Quantity(1, new UnitOfMeasure("Piece")),
            scrapPercentage);
}