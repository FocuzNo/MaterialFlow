using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.PlanningRuns;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.PurchaseRequests;

public sealed class PurchaseRequest : Entity
{
    private PurchaseRequest() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public Guid? PlanningRunId { get; private set; }
    public PlanningRun? PlanningRun { get; private set; }

    public decimal Quantity { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public DateOnly RequestedDeliveryDate { get; private set; }

    public string? PurchasingGroup { get; private set; }

    public string Status { get; private set; }

    public static PurchaseRequest Create(
        Guid id,
        Guid materialId,
        Guid siteId,
        Guid? planningRunId,
        decimal quantity,
        UnitOfMeasure unitOfMeasure,
        DateOnly requestedDeliveryDate,
        string? purchasingGroup,
        string status = "Created")
        => new()
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            PlanningRunId = planningRunId,
            Quantity = quantity,
            UnitOfMeasure = unitOfMeasure,
            RequestedDeliveryDate = requestedDeliveryDate,
            PurchasingGroup = purchasingGroup,
            Status = status
        };

    public void Update(
        decimal quantity,
        DateOnly requestedDeliveryDate,
        string? purchasingGroup,
        string status)
    {
        Quantity = quantity;
        RequestedDeliveryDate = requestedDeliveryDate;
        PurchasingGroup = purchasingGroup;
        Status = status;
    }
}
