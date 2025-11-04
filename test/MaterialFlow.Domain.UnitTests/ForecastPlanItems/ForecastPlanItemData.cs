using MaterialFlow.Domain.ForecastPlanItems;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ForecastPlanItems;

internal static class ForecastPlanItemData
{
    public static ForecastPlanItem CreateItem(
        Guid? id = null,
        Guid? forecastPlanId = null,
        DateOnly? periodStartDate = null,
        Quantity? quantity = null,
        string? consumptionIndicator = null) =>
        ForecastPlanItem.Create(
            id ?? Guid.NewGuid(),
            forecastPlanId ?? Guid.NewGuid(),
            periodStartDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            quantity ?? new Quantity(100, new UnitOfMeasure("Piece")),
            consumptionIndicator);
}