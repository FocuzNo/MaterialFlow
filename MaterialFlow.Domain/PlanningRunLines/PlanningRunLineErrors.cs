namespace MaterialFlow.Domain.PlanningRunLines;

public static class PlanningRunLineErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(PlanningRunLine)}.{NotFound}",
        "The planning run line with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(PlanningRunLine)}.{InvalidUpdate}",
        "The planning run line update is invalid");
}