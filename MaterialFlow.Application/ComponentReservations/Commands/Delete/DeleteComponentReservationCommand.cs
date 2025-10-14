namespace MaterialFlow.Application.ComponentReservations.Commands.Delete;

public sealed record DeleteComponentReservationCommand(Guid Id) : IRequest<Result>;