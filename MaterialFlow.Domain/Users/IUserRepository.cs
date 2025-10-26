namespace MaterialFlow.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<User?> GetByIdentityIdAsync(string identityId, CancellationToken cancellationToken = default);

    Task<bool> IsUniqueAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> IsUniqueAsync(Guid id, string email, CancellationToken cancellationToken = default);
}