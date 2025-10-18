using MaterialFlow.Domain.PlanningRuns;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class PlanningRunRepository(ApplicationDbContext dbContext)
    : Repository<PlanningRun>(dbContext), IPlanningRunRepository;