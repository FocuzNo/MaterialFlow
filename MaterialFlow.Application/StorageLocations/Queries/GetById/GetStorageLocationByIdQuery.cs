namespace MaterialFlow.Application.StorageLocations.Queries.GetById;

public sealed record GetStorageLocationByIdQuery(Guid Id) : IRequest<Result<StorageLocationResponse>>;