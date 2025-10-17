using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.PlanningAreas;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;
using MaterialFlow.Domain.ForecastPlans.Events;
using MaterialFlow.Domain.ForecastPlanItems;

namespace MaterialFlow.Domain.ForecastPlans;

public sealed class ForecastPlan : Entity
{
    private readonly List<ForecastPlanItem> _items = [];

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

    public IReadOnlyCollection<ForecastPlanItem> Items => _items.AsReadOnly();

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
    {
        var forecastPlan = new ForecastPlan
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

        forecastPlan.RaiseDomainEvent(new ForecastPlanCreatedDomainEvent(forecastPlan.Id));

        return forecastPlan;
    }

    public ForecastPlanItem AddItem(
        DateOnly periodStartDate,
        Quantity quantity)
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

        RaiseDomainEvent(new ForecastPlanUpdatedDomainEvent(Id));
    }

    public void Delete()
    {
        RaiseDomainEvent(new ForecastPlanDeletedDomainEvent(Id));
    }
}
