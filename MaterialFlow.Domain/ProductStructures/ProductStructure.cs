using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.ProductStructures;

public sealed class ProductStructure : Entity
{
    private ProductStructure() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid? SiteId { get; private set; }
    public Site? Site { get; private set; }

    public BillOfMaterialsUsage Usage { get; private set; }

    public string? AlternativeNumber { get; private set; }

    public DateOnly ValidFromDate { get; private set; }

    public DateOnly? ValidToDate { get; private set; }

    public OrderStatus OrderStatus { get; private set; }

    private readonly List<ProductComponent> _components = [];

    public IReadOnlyCollection<ProductComponent> Components =>
        _components.AsReadOnly();

    public static ProductStructure Create(
        Guid id,
        Guid materialId,
        Guid? siteId,
        BillOfMaterialsUsage usage,
        string? alternativeNumber,
        DateOnly validFromDate,
        DateOnly? validToDate,
        OrderStatus orderStatus)
        => new()
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            Usage = usage,
            AlternativeNumber = alternativeNumber,
            ValidFromDate = validFromDate,
            ValidToDate = validToDate,
            OrderStatus = orderStatus
        };

    public ProductComponent AddComponent(
        Guid componentMaterialId,
        UnitOfMeasure unitOfMeasure,
        Quantity quantityPer,
        decimal? scrapPercentage)
    {
        var component = ProductComponent.Create(
            Guid.NewGuid(),
            Id,
            componentMaterialId,
            unitOfMeasure,
            quantityPer,
            scrapPercentage);

        _components.Add(component);

        return component;
    }

    public void RemoveComponent(Guid componentId)
    {
        var component = _components
            .FirstOrDefault(x => x.Id == componentId);

        if (component is not null)
            _components.Remove(component);
    }

    public void Update(
        Guid materialId,
        Guid? siteId,
        BillOfMaterialsUsage usage,
        string? alternativeNumber,
        DateOnly validFromDate,
        DateOnly? validToDate,
        OrderStatus orderStatus)
    {
        MaterialId = materialId;
        SiteId = siteId;
        Usage = usage;
        AlternativeNumber = alternativeNumber;
        ValidFromDate = validFromDate;
        ValidToDate = validToDate;
        OrderStatus = orderStatus;
    }
}
