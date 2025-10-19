using MaterialFlow.Domain.ProductStructures;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class ProductStructureRepository(ApplicationDbContext dbContext)
    : Repository<ProductStructure>(dbContext), IProductStructureRepository;