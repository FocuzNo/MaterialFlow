using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Application.StorageLocations.Queries.GetAll;

internal sealed class GetAllStorageLocationsQueryHandler(IStorageLocationRepository storageLocationRepository)
    : IRequestHandler<GetAllStorageLocationsQuery, Result<IReadOnlyCollection<StorageLocationResponse>>>
{
    public async Task<Result<IReadOnlyCollection<StorageLocationResponse>>> Handle(
        GetAllStorageLocationsQuery request,
        CancellationToken cancellationToken)
    {
        var storageLocations = await storageLocationRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<StorageLocationResponse>)[.. storageLocations
            .Select(x => new StorageLocationResponse(
                x.Id,
                x.SiteId,
                x.Code,
                x.Name)
            )]);
    }
}