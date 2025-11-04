using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Domain.UnitTests.PlanningAreas;

internal static class PlanningAreaData
{
    public static PlanningArea CreateArea(
        Guid? id = null,
        string? planningAreaCode = null,
        string? description = null,
        Guid? siteId = null) =>
        PlanningArea.Create(
            id ?? Guid.NewGuid(),
            planningAreaCode ?? "PA-001",
            description ?? "Main Planning Area",
            siteId ?? Guid.NewGuid());
}