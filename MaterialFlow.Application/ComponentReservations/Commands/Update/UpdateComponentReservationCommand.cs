namespace MaterialFlow.Application.ComponentReservations.Commands.Update;

public sealed record UpdateComponentReservationCommand(
    Guid Id,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    int Status) : IRequest<Result>;