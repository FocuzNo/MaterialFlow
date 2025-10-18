using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.ProductStructures;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.ProductComponents;

public sealed class ProductComponent : Entity
{
    private ProductComponent() { }

    public Guid ProductStructureId { get; private set; }
    public ProductStructure ProductStructure { get; private set; }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public Quantity QuantityPer { get; private set; }

    public decimal? ScrapPercentage { get; private set; }

    public static ProductComponent Create(
        Guid id,
        Guid productStructureId,
        Guid materialId,
        UnitOfMeasure unitOfMeasure,
        Quantity quantityPer,
        decimal? scrapPercentage)
        => new()
        {
            Id = id,
            ProductStructureId = productStructureId,
            MaterialId = materialId,
            UnitOfMeasure = unitOfMeasure,
            QuantityPer = quantityPer,
            ScrapPercentage = scrapPercentage
        };

    public void Update(
        UnitOfMeasure unitOfMeasure,
        Quantity quantityPer,
        decimal? scrapPercentage)
    {
        UnitOfMeasure = unitOfMeasure;
        QuantityPer = quantityPer;
        ScrapPercentage = scrapPercentage;
    }
}
