namespace MaterialFlow.Domain.ForecastPlans;

public static class ForecastPlanErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(ForecastPlan)}.{NotFound}",
        "The forecast plan with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(ForecastPlan)}.{InvalidUpdate}",
        "The forecast plan update is invalid");
}