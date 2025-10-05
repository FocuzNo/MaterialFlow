using MaterialFlow.Domain.Materials;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class MaterialRepository(DbContext dbContext)
    : Repository<Material>(dbContext), IMaterialRepository;