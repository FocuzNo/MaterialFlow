namespace MaterialFlow.Application.ComponentReservations.Commands.Update;

public sealed record UpdateComponentReservationCommand(
    Guid Id,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string UnitOfMeasure,
    int Status) : IRequest<Result>;
