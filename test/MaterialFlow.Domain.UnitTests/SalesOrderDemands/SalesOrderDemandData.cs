using MaterialFlow.Domain.SalesOrderDemands;
using MaterialFlow.Domain.SalesOrderDemands.ValueObjects;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.SalesOrderDemands;

internal static class SalesOrderDemandData
{
    public static SalesOrderDemand CreateDemand(
        Guid? id = null,
        Guid? materialId = null,
        Guid? siteId = null,
        DateOnly? requirementDate = null,
        Quantity? quantity = null,
        UnitOfMeasure? unitOfMeasure = null,
        SourceDocument? sourceDocument = null) =>
        SalesOrderDemand.Create(
            id ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId ?? Guid.NewGuid(),
            requirementDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddDays(14)),
            quantity ?? new Quantity(100, new UnitOfMeasure("Piece")),
            unitOfMeasure ?? new UnitOfMeasure("Piece"),
            sourceDocument ?? new SourceDocument("SalesOrder", "SO-10001", "10"));
}