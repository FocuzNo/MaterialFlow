using MaterialFlow.Domain.PlannedProductionOrders;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class PlannedProductionOrderRepository(ApplicationDbContext dbContext)
    : Repository<PlannedProductionOrder>(dbContext), IPlannedProductionOrderRepository;