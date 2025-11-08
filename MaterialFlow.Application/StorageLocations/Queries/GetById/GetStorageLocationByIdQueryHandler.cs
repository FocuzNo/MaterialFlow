using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Application.StorageLocations.Queries.GetById;

internal sealed class GetStorageLocationByIdQueryHandler(IStorageLocationRepository storageLocationRepository)
    : IRequestHandler<GetStorageLocationByIdQuery, Result<StorageLocationResponse>>
{
    public async Task<Result<StorageLocationResponse>> Handle(
        GetStorageLocationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var storageLocation = await storageLocationRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (storageLocation is null)
        {
            return Result.Failure<StorageLocationResponse>(StorageLocationErrors.NotFound);
        }

        var response = new StorageLocationResponse(
            storageLocation.Id,
            storageLocation.SiteId,
            storageLocation.Code,
            storageLocation.Name);

        return Result.Success(response);
    }
}