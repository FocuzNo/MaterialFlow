using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class PlanningAreaRepository(ApplicationDbContext dbContext)
    : Repository<PlanningArea>(dbContext), IPlanningAreaRepository;