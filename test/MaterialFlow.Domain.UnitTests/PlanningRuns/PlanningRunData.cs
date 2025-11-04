using MaterialFlow.Domain.PlanningRuns;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.PlanningRuns;

internal static class PlanningRunData
{
    public static PlanningRun CreateRun(
        Guid? id = null,
        DateTime? runTimestampUtc = null,
        Guid? siteId = null,
        Guid? planningAreaId = null,
        int? planningHorizonInDays = null,
        string? startedByUser = null,
        OrderStatus? orderStatus = null) =>
        PlanningRun.Create(
            id ?? Guid.NewGuid(),
            runTimestampUtc ?? DateTime.UtcNow,
            siteId,
            planningAreaId,
            planningHorizonInDays ?? 90,
            startedByUser ?? "system.admin",
            orderStatus ?? OrderStatus.Created);
}