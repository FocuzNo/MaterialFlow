namespace MaterialFlow.Application.ComponentReservations.Queries.GetById;

public sealed record GetComponentReservationByIdQuery(Guid Id) : IRequest<Result<ComponentReservationResponse>>;
