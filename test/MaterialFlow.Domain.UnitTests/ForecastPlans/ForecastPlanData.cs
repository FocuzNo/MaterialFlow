using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ForecastPlans;

internal static class ForecastPlanData
{
    public static ForecastPlan CreatePlan(
        Guid? id = null,
        Guid? materialId = null,
        Guid? siteId = null,
        Guid? planningAreaId = null,
        string? version = null,
        string? planningStrategy = null,
        UnitOfMeasure? unitOfMeasure = null,
        PeriodGranularity? periodGranularity = null,
        DateRange? dateRange = null) =>
        ForecastPlan.Create(
            id ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId,
            planningAreaId,
            version ?? "1.0",
            planningStrategy ?? "MRP",
            unitOfMeasure ?? new UnitOfMeasure("Piece"),
            periodGranularity ?? PeriodGranularity.Month,
            dateRange ?? new DateRange(
                DateOnly.FromDateTime(DateTime.UtcNow),
                DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(12))));
}