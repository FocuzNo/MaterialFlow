using MaterialFlow.Application.ComponentReservations.Queries.GetById;

namespace MaterialFlow.Application.ComponentReservations.Queries.GetAll;

public sealed record GetAllComponentReservationsQuery : IRequest<Result<IReadOnlyCollection<ComponentReservationResponse>>>;