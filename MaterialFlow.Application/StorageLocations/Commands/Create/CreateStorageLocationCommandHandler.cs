using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Application.StorageLocations.Commands.Create;

internal sealed class CreateStorageLocationCommandHandler(
    IStorageLocationRepository storageLocationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateStorageLocationCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateStorageLocationCommand request,
        CancellationToken cancellationToken)
    {
        var isUnique = await storageLocationRepository.IsUniqueAsync(
            request.Code,
            cancellationToken);

        if (!isUnique)
        {
            return Result.Failure<Guid>(StorageLocationErrors.AlreadyExists);
        }

        var storageLocation = StorageLocation.Create(
            Guid.NewGuid(),
            request.SiteId,
            request.Code,
            request.Name);

        await storageLocationRepository.AddAsync(
            storageLocation,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(storageLocation.Id);
    }
}