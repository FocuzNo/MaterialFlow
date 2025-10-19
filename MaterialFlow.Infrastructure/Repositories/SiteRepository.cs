using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class SiteRepository(ApplicationDbContext dbContext)
    : Repository<Site>(dbContext), ISiteRepository;