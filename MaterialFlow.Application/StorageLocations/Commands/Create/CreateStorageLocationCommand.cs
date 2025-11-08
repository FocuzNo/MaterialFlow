namespace MaterialFlow.Application.StorageLocations.Commands.Create;

public sealed record CreateStorageLocationCommand(
    Guid SiteId,
    string Code,
    string Name) : IRequest<Result<Guid>>;