using MaterialFlow.Domain.Materials;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class MaterialRepository(ApplicationDbContext dbContext)
    : Repository<Material>(dbContext), IMaterialRepository;