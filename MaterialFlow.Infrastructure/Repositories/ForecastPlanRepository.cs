using MaterialFlow.Domain.ForecastPlans;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class ForecastPlanRepository(ApplicationDbContext dbContext)
    : Repository<ForecastPlan>(dbContext), IForecastPlanRepository;