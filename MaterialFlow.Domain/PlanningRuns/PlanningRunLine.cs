using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.PlanningRuns;

public sealed class PlanningRunLine : Entity
{
    private PlanningRunLine() { }

    public Guid PlanningRunId { get; private set; }
    public PlanningRun PlanningRun { get; private set; }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public DateOnly RequirementDate { get; private set; }

    public Quantity RequirementQuantity { get; private set; }

    public Quantity AvailableQuantity { get; private set; }

    public Quantity ShortageQuantity { get; private set; }

    public string RecommendedAction { get; private set; }

    public DateOnly? RescheduleDate { get; private set; }

    public static PlanningRunLine Create(
        Guid id,
        Guid planningRunId,
        Guid materialId,
        Guid siteId,
        DateOnly requirementDate,
        Quantity requirementQuantity,
        Quantity availableQuantity,
        Quantity shortageQuantity,
        string recommendedAction,
        DateOnly rescheduleDate)
        => new()
        {
            Id = id,
            PlanningRunId = planningRunId,
            MaterialId = materialId,
            SiteId = siteId,
            RequirementDate = requirementDate,
            RequirementQuantity = requirementQuantity,
            AvailableQuantity = availableQuantity,
            ShortageQuantity = shortageQuantity,
            RecommendedAction = recommendedAction,
            RescheduleDate = rescheduleDate
        };

    public void Update(
        DateOnly requirementDate,
        Quantity requirementQuantity,
        Quantity availableQuantity,
        Quantity shortageQuantity,
        string recommendedAction,
        DateOnly rescheduleDate)
    {
        RequirementQuantity = requirementQuantity;
        AvailableQuantity = availableQuantity;
        ShortageQuantity = shortageQuantity;
        RecommendedAction = recommendedAction;
        RescheduleDate = rescheduleDate;
    }
}
