using MaterialFlow.Domain.PlanningRunLines;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class PlanningRunLineRepository(ApplicationDbContext dbContext)
    : Repository<PlanningRunLine>(dbContext), IPlanningRunLineRepository;