namespace MaterialFlow.Application.StorageLocations.Queries;

public sealed record StorageLocationResponse(
    Guid Id,
    Guid SiteId,
    string Code,
    string Name);