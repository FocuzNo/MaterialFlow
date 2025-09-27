namespace MaterialFlow.Domain.PlanningAreas;

public static class PlanningAreaErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(PlanningArea)}.{NotFound}",
        "The planning area with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(PlanningArea)}.{InvalidUpdate}",
        "The planning area update is invalid");
}