using MaterialFlow.Domain.ForecastPlanItems;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class ForecastPlanItemRepository(ApplicationDbContext dbContext)
    : Repository<ForecastPlanItem>(dbContext), IForecastPlanItemRepository;