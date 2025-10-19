using MaterialFlow.Domain.PurchaseRequests;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class PurchaseRequestRepository(ApplicationDbContext dbContext)
    : Repository<PurchaseRequest>(dbContext), IPurchaseRequestRepository;