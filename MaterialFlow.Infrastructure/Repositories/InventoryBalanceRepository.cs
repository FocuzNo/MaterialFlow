using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class InventoryBalanceRepository(ApplicationDbContext dbContext)
    : Repository<InventoryBalance>(dbContext), IInventoryBalanceRepository;