public sealed record ProductStructureResponse(
    Guid Id,
    Guid MaterialId,
    Guid? SiteId,
    string Usage,
    string? AlternativeNumber,
    DateOnly ValidFromDate,
    DateOnly? ValidToDate,
    string OrderStatus,
    int ComponentsCount);