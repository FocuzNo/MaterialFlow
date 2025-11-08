using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class StorageLocationRepository(ApplicationDbContext dbContext)
    : Repository<StorageLocation>(dbContext), IStorageLocationRepository
{
    public async Task<bool> IsUniqueAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        return !await _dbSet
            .AnyAsync(x =>
                x.Code == code,
                cancellationToken);
    }

    public async Task<bool> IsUniqueAsync(
        Guid id,
        string code,
        CancellationToken cancellationToken = default)
    {
        return !await _dbSet
            .AnyAsync(x =>
                x.Code == code,
                cancellationToken);
    }
}