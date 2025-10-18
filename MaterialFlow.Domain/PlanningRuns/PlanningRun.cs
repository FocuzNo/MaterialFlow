using MaterialFlow.Domain.PlanningAreas;
using MaterialFlow.Domain.PlanningRunLines;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.PlanningRuns;

public sealed class PlanningRun : Entity
{
    private PlanningRun() { }

    public DateTime RunTimestampUtc { get; private set; }

    public Guid? SiteId { get; private set; }
    public Site? Site { get; private set; }

    public Guid? PlanningAreaId { get; private set; }
    public PlanningArea? PlanningArea { get; private set; }

    public int PlanningHorizonInDays { get; private set; }

    public string StartedByUser { get; private set; }

    public OrderStatus OrderStatus { get; private set; }

    private readonly List<PlanningRunLine> _lines = new();

    public IReadOnlyCollection<PlanningRunLine> Lines => _lines.AsReadOnly();

    public static PlanningRun Create(
        Guid id,
        DateTime runTimestampUtc,
        Guid? siteId,
        Guid? planningAreaId,
        int planningHorizonInDays,
        string startedByUser,
        OrderStatus orderStatus)
        => new()
        {
            Id = id,
            RunTimestampUtc = runTimestampUtc,
            SiteId = siteId,
            PlanningAreaId = planningAreaId,
            PlanningHorizonInDays = planningHorizonInDays,
            StartedByUser = startedByUser,
            OrderStatus = orderStatus
        };

    public void Update(
        int planningHorizonInDays,
        OrderStatus orderStatus)
    {
        PlanningHorizonInDays = planningHorizonInDays;
        OrderStatus = orderStatus;
    }

    public void AddLine(PlanningRunLine line) =>
        _lines.Add(line);
}
