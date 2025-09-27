namespace MaterialFlow.Domain.PlanningRuns;

public static class PlanningRunErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(PlanningRun)}.{NotFound}",
        "The planning run with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(PlanningRun)}.{InvalidUpdate}",
        "The planning run update is invalid");
}