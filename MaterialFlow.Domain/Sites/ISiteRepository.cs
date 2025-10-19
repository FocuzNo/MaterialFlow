namespace MaterialFlow.Domain.Sites;

public interface ISiteRepository : IRepository<Site>
{
    Task<bool> IsUniqueAsync(string plantCode, CancellationToken cancellationToken = default);

    Task<bool> IsUniqueAsync(Guid id, string plantCode, CancellationToken cancellationToken = default);
}