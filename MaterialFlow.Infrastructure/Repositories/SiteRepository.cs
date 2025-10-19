using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class SiteRepository(ApplicationDbContext dbContext)
    : Repository<Site>(dbContext), ISiteRepository
{
    public async Task<bool> IsUniqueAsync(
        string plantCode,
        CancellationToken cancellationToken = default)
    {
        return !await _dbSet
            .AnyAsync(s =>
                s.PlantCode == plantCode,
                cancellationToken);
    }

    public async Task<bool> IsUniqueAsync(
        Guid id,
        string plantCode,
        CancellationToken cancellationToken = default)
    {
        return !await _dbSet
            .AnyAsync(s =>
                s.PlantCode == plantCode,
                cancellationToken);
    }
}