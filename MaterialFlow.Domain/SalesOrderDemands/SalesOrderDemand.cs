using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.SalesOrderDemands;

public sealed class SalesOrderDemand : Entity
{
    private SalesOrderDemand() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public DateOnly RequirementDate { get; private set; }

    public decimal Quantity { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public string SourceDocumentType { get; private set; }

    public string SourceDocumentNumber { get; private set; }

    public string SourceDocumentItemNumber { get; private set; }

    public static SalesOrderDemand Create(
        Guid id,
        Guid materialId,
        Guid siteId,
        DateOnly requirementDate,
        decimal quantity,
        UnitOfMeasure unitOfMeasure,
        string sourceDocumentType,
        string sourceDocumentNumber,
        string sourceDocumentItemNumber)
        => new()
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            RequirementDate = requirementDate,
            Quantity = quantity,
            UnitOfMeasure = unitOfMeasure,
            SourceDocumentType = sourceDocumentType,
            SourceDocumentNumber = sourceDocumentNumber,
            SourceDocumentItemNumber = sourceDocumentItemNumber
        };

    public void Update(
        DateOnly requirementDate,
        decimal quantity,
        UnitOfMeasure unitOfMeasure)
    {
        RequirementDate = requirementDate;
        Quantity = quantity;
        UnitOfMeasure = unitOfMeasure;
    }
}
