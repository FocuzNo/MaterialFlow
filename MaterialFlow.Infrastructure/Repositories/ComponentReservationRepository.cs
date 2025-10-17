using MaterialFlow.Domain.ComponentReservations;

namespace MaterialFlow.Infrastructure.Repositories;

internal sealed class ComponentReservationRepository(ApplicationDbContext dbContext)
    : Repository<ComponentReservation>(dbContext), IComponentReservationRepository;