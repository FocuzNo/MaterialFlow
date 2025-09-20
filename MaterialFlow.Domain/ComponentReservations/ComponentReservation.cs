using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.ComponentReservations;

public sealed class ComponentReservation : Entity
{
    private ComponentReservation() { }

    public string SourceOrderType { get; private set; }
    public Guid SourceOrderId { get; private set; }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public DateOnly RequirementDate { get; private set; }

    public decimal Quantity { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public string Status { get; private set; }

    public static ComponentReservation Create(
        Guid id,
        string sourceOrderType,
        Guid sourceOrderId,
        Guid materialId,
        Guid siteId,
        DateOnly requirementDate,
        decimal quantity,
        UnitOfMeasure unitOfMeasure,
        string status = "Open")
        => new()
        {
            Id = id,
            SourceOrderType = sourceOrderType,
            SourceOrderId = sourceOrderId,
            MaterialId = materialId,
            SiteId = siteId,
            RequirementDate = requirementDate,
            Quantity = quantity,
            UnitOfMeasure = unitOfMeasure,
            Status = status
        };

    public void Update(
        DateOnly requirementDate,
        decimal quantity,
        UnitOfMeasure unitOfMeasure,
        string status)
    {
        RequirementDate = requirementDate;
        Quantity = quantity;
        UnitOfMeasure = unitOfMeasure;
        Status = status;
    }
}
