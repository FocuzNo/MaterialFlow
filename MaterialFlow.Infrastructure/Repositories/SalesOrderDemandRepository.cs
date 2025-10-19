using MaterialFlow.Domain.SalesOrderDemands;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class SalesOrderDemandRepository(ApplicationDbContext dbContext)
    : Repository<SalesOrderDemand>(dbContext), ISalesOrderDemandRepository;
