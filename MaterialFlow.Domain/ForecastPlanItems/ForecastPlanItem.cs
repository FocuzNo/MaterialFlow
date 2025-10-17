using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.ForecastPlanItems.Events;

namespace MaterialFlow.Domain.ForecastPlanItems;

public sealed class ForecastPlanItem : Entity
{
    private ForecastPlanItem() { }

    public Guid ForecastPlanId { get; private set; }
    public ForecastPlan ForecastPlan { get; private set; }

    public DateOnly PeriodStartDate { get; private set; }

    public Quantity Quantity { get; private set; }

    public string? ConsumptionIndicator { get; private set; }

    public static ForecastPlanItem Create(
        Guid id,
        Guid forecastPlanId,
        DateOnly periodStartDate,
        Quantity quantity,
        string? consumptionIndicator)
    {
        var item = new ForecastPlanItem
        {
            Id = id,
            ForecastPlanId = forecastPlanId,
            PeriodStartDate = periodStartDate,
            Quantity = quantity,
            ConsumptionIndicator = consumptionIndicator
        };

        item.RaiseDomainEvent(new ForecastPlanItemCreatedDomainEvent(
            item.Id,
            forecastPlanId));

        return item;
    }

    public void Update(
        DateOnly periodStartDate,
        Quantity quantity,
        string? consumptionIndicator)
    {
        PeriodStartDate = periodStartDate;
        Quantity = quantity;
        ConsumptionIndicator = consumptionIndicator;

        RaiseDomainEvent(new ForecastPlanItemUpdatedDomainEvent(
            Id,
            ForecastPlanId));
    }

    public void Delete()
    {
        RaiseDomainEvent(new ForecastPlanItemDeletedDomainEvent(
            Id,
            ForecastPlanId));
    }
}
