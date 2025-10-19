using MaterialFlow.Domain.ProductionOrders;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class ProductionOrderRepository(ApplicationDbContext dbContext)
    : Repository<ProductionOrder>(dbContext), IProductionOrderRepository;