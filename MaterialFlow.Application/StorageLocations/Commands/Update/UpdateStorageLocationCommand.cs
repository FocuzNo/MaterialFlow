namespace MaterialFlow.Application.StorageLocations.Commands.Update;

public sealed record UpdateStorageLocationCommand(
    Guid Id,
    string Code,
    string Name) : IRequest<Result>;