using MaterialFlow.Domain.ForecastPlans;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class ForecastPlanItemRepository(ApplicationDbContext dbContext)
    : Repository<ForecastPlanItem>(dbContext), IForecastPlanItemRepository;