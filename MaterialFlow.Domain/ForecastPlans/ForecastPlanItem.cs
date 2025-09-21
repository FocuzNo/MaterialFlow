using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.ForecastPlans;

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
        => new()
        {
            Id = id,
            ForecastPlanId = forecastPlanId,
            PeriodStartDate = periodStartDate,
            Quantity = quantity,
            ConsumptionIndicator = consumptionIndicator
        };

    public void Update(
        DateOnly periodStartDate,
        Quantity quantity,
        string? consumptionIndicator)
    {
        PeriodStartDate = periodStartDate;
        Quantity = quantity;
        ConsumptionIndicator = consumptionIndicator;
    }
}
