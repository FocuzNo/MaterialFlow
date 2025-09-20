using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
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

    public decimal RequirementQuantity { get; private set; }

    public decimal AvailableQuantity { get; private set; }

    public decimal ShortageQuantity { get; private set; }

    public RecommendedActionCode? RecommendedActionCode { get; private set; }

    public DateOnly? RescheduleDate { get; private set; }

    public static PlanningRunLine Create(
        Guid id,
        Guid planningRunId,
        Guid materialId,
        Guid siteId,
        DateOnly requirementDate,
        decimal requirementQuantity,
        decimal availableQuantity,
        decimal shortageQuantity,
        RecommendedActionCode? recommendedActionCode = null,
        DateOnly? rescheduleDate = null)
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
            RecommendedActionCode = recommendedActionCode,
            RescheduleDate = rescheduleDate
        };

    public void Update(
        decimal requirementQuantity,
        decimal availableQuantity,
        decimal shortageQuantity,
        RecommendedActionCode? recommendedActionCode,
        DateOnly? rescheduleDate)
    {
        RequirementQuantity = requirementQuantity;
        AvailableQuantity = availableQuantity;
        ShortageQuantity = shortageQuantity;
        RecommendedActionCode = recommendedActionCode;
        RescheduleDate = rescheduleDate;
    }
}
