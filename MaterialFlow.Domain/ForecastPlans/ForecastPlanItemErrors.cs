namespace MaterialFlow.Domain.ForecastPlans;

public static class ForecastPlanItemErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(ForecastPlanItem)}.{NotFound}",
        "The forecast plan item with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(ForecastPlanItem)}.{InvalidUpdate}",
        "The forecast plan item update is invalid");
}