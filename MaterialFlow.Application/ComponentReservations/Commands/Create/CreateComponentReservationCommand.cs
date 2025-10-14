namespace MaterialFlow.Application.ComponentReservations.Commands.Create;

public sealed record CreateComponentReservationCommand(
    string SourceOrderType,
    Guid SourceOrderId,
    Guid MaterialId,
    Guid SiteId,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string UnitOfMeasure,
    int Status) : IRequest<Guid>;