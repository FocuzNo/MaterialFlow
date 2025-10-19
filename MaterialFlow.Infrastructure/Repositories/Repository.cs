using MaterialFlow.Domain.Abstractions;

namespace MaterialFlow.Infrastructure.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext)
    : IRepository<TEntity> where TEntity : Entity
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    internal readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FindAsync(
                [id],
                cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await _dbSet
            .AddAsync(
                entity,
                cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}