using MaterialFlow.Domain.ProductComponents;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class ProductComponentRepository(ApplicationDbContext dbContext)
    : Repository<ProductComponent>(dbContext), IProductComponentRepository;