using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.PlanningAreas;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.ForecastPlans;

public sealed class ForecastPlan : Entity
{
    private ForecastPlan() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid? SiteId { get; private set; }
    public Site? Site { get; private set; }

    public Guid? PlanningAreaId { get; private set; }
    public PlanningArea? PlanningArea { get; private set; }

    public string Version { get; private set; }

    public string PlanningStrategy { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public PeriodGranularity PeriodGranularity { get; private set; }

    public DateRange DateRange { get; private set; }

    private readonly List<ForecastPlanItem> _items = [];

    public IReadOnlyCollection<ForecastPlanItem> Items =>
        _items.AsReadOnly();

    public static ForecastPlan Create(
        Guid id,
        Guid materialId,
        Guid? siteId,
        Guid? planningAreaId,
        string version,
        string planningStrategy,
        UnitOfMeasure unitOfMeasure,
        PeriodGranularity periodGranularity,
        DateRange dateRange)
        => new()
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            PlanningAreaId = planningAreaId,
            Version = version,
            PlanningStrategy = planningStrategy,
            UnitOfMeasure = unitOfMeasure,
            PeriodGranularity = periodGranularity,
            DateRange = dateRange
        };

    public ForecastPlanItem AddItem(
        DateOnly periodStartDate,
        decimal quantity)
    {
        var item = ForecastPlanItem.Create(
            Guid.NewGuid(),
            Id,
            periodStartDate,
            quantity,
            null);

        _items.Add(item);

        return item;
    }

    public void Update(
        string version,
        string planningStrategy,
        UnitOfMeasure unitOfMeasure,
        PeriodGranularity periodGranularity,
        DateRange dateRange)
    {
        Version = version;
        PlanningStrategy = planningStrategy;
        UnitOfMeasure = unitOfMeasure;
        PeriodGranularity = periodGranularity;
        DateRange = dateRange;
    }
}
