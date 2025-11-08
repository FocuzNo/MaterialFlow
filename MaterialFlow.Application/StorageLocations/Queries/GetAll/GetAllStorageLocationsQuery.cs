namespace MaterialFlow.Application.StorageLocations.Queries.GetAll;

public sealed record GetAllStorageLocationsQuery : IRequest<Result<IReadOnlyCollection<StorageLocationResponse>>>;