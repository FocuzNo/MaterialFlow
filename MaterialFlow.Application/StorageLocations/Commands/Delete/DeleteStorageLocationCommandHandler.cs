using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Application.StorageLocations.Commands.Delete;

internal sealed class DeleteStorageLocationCommandHandler(
    IStorageLocationRepository storageLocationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteStorageLocationCommand, Result>
{
    public async Task<Result> Handle(
        DeleteStorageLocationCommand request,
        CancellationToken cancellationToken)
    {
        var storageLocation = await storageLocationRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (storageLocation is null)
        {
            return Result.Failure(StorageLocationErrors.NotFound);
        }

        storageLocationRepository.Delete(storageLocation);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}