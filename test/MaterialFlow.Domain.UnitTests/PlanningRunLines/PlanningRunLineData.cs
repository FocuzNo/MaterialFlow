using MaterialFlow.Domain.PlanningRunLines;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.PlanningRunLines;

internal static class PlanningRunLineData
{
    public static PlanningRunLine CreateLine(
        Guid? id = null,
        Guid? planningRunId = null,
        Guid? materialId = null,
        Guid? siteId = null,
        DateOnly? requirementDate = null,
        Quantity? requirementQuantity = null,
        Quantity? availableQuantity = null,
        Quantity? shortageQuantity = null,
        string? recommendedAction = null,
        DateOnly? rescheduleDate = null) =>
        PlanningRunLine.Create(
            id ?? Guid.NewGuid(),
            planningRunId ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            requirementDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            requirementQuantity ?? new Quantity(100, new UnitOfMeasure("Piece")),
            availableQuantity ?? new Quantity(80, new UnitOfMeasure("Piece")),
            shortageQuantity ?? new Quantity(20, new UnitOfMeasure("Piece")),
            recommendedAction ?? "Purchase Order",
            rescheduleDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddDays(3)));
}