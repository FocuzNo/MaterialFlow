namespace MaterialFlow.Domain.StorageLocations;

public interface IStorageLocationRepository : IRepository<StorageLocation>
{
    Task<bool> IsUniqueAsync(string plantCode, CancellationToken cancellationToken = default);

    Task<bool> IsUniqueAsync(Guid id, string plantCode, CancellationToken cancellationToken = default);
}