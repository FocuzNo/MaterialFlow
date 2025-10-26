using MaterialFlow.Domain.Users;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class UserRepository(ApplicationDbContext dbContext)
    : Repository<User>(dbContext), IUserRepository
{
    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<User>()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .FirstOrDefaultAsync(u => u.Email.Value == email, cancellationToken);
    }

    public async Task<User?> GetByIdentityIdAsync(
        string identityId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<User>()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .FirstOrDefaultAsync(
                u => u.IdentityId == identityId,
                cancellationToken);
    }

    public async Task<bool> IsUniqueAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return !await dbContext.Set<User>()
            .AnyAsync(
                u => u.Email.Value == email,
                cancellationToken);
    }

    public async Task<bool> IsUniqueAsync(
        Guid id,
        string email,
        CancellationToken cancellationToken = default)
    {
        return !await dbContext.Set<User>()
            .AnyAsync(
                u => u.Id != id
                && u.Email.Value == email,
                cancellationToken);
    }
}
