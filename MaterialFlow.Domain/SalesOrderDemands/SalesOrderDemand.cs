using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.SalesOrderDemands.ValueObjects;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;
using MaterialFlow.Domain.SalesOrderDemands.Events;

namespace MaterialFlow.Domain.SalesOrderDemands;

public sealed class SalesOrderDemand : Entity
{
    private SalesOrderDemand() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public DateOnly RequirementDate { get; private set; }

    public Quantity Quantity { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public SourceDocument SourceDocument { get; private set; }

    public static SalesOrderDemand Create(
        Guid id,
        Guid materialId,
        Guid siteId,
        DateOnly requirementDate,
        Quantity quantity,
        UnitOfMeasure unitOfMeasure,
        SourceDocument sourceDocument)
    {
        var salesOrderDemand = new SalesOrderDemand
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            RequirementDate = requirementDate,
            Quantity = quantity,
            UnitOfMeasure = unitOfMeasure,
            SourceDocument = sourceDocument
        };

        salesOrderDemand.RaiseDomainEvent(new SalesOrderDemandCreatedDomainEvent(salesOrderDemand.Id));

        return salesOrderDemand;
    }

    public void Update(
        DateOnly requirementDate,
        Quantity quantity,
        UnitOfMeasure unitOfMeasure)
    {
        RequirementDate = requirementDate;
        Quantity = quantity;
        UnitOfMeasure = unitOfMeasure;

        RaiseDomainEvent(new SalesOrderDemandUpdatedDomainEvent(Id));
    }
}
