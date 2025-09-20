using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.PlanningAreas;

public sealed class PlanningArea : Entity
{
    private PlanningArea() { }

    public string PlanningAreaCode { get; private set; }

    public string Description { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public static PlanningArea Create(
        Guid id,
        string planningAreaCode,
        string description,
        Guid siteId)
        => new()
        {
            Id = id,
            PlanningAreaCode = planningAreaCode,
            Description = description,
            SiteId = siteId
        };

    public void Update(
        string planningAreaCode,
        string description,
        Guid siteId)
    {
        PlanningAreaCode = planningAreaCode;
        Description = description;
        SiteId = siteId;
    }
}
