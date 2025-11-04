using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.ProductStructures;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ProductStructures;

internal static class ProductStructureData
{
    public static ProductStructure CreateStructure(
        Guid? id = null,
        Guid? materialId = null,
        Guid? siteId = null,
        BillOfMaterialsUsage? usage = null,
        string? alternativeNumber = null,
        DateOnly? validFromDate = null,
        DateOnly? validToDate = null,
        OrderStatus? orderStatus = null) =>
        ProductStructure.Create(
            id ?? Guid.NewGuid(),
            materialId ?? Guid.NewGuid(),
            siteId,
            usage ?? BillOfMaterialsUsage.Production,
            alternativeNumber,
            validFromDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            validToDate,
            orderStatus ?? OrderStatus.Created);
}