using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Application.StorageLocations.Commands.Update;

internal sealed class UpdateStorageLocationCommandHandler(
    IStorageLocationRepository storageLocationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateStorageLocationCommand, Result>
{
    public async Task<Result> Handle(
        UpdateStorageLocationCommand request,
        CancellationToken cancellationToken)
    {
        var storageLocation = await storageLocationRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (storageLocation is null)
        {
            return Result.Failure(StorageLocationErrors.NotFound);
        }

        var isUnique = await storageLocationRepository.IsUniqueAsync(
            request.Id,
            request.Code,
            cancellationToken);

        if (!isUnique)
        {
            return Result.Failure(StorageLocationErrors.AlreadyExists);
        }

        storageLocation.Update(
            request.Code,
            request.Name);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}