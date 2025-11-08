namespace MaterialFlow.Application.StorageLocations.Commands.Delete;

public sealed record DeleteStorageLocationCommand(Guid Id) : IRequest<Result>;