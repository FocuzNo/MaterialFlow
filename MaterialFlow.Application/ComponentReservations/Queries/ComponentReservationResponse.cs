namespace MaterialFlow.Application.ComponentReservations.Queries;

public sealed record ComponentReservationResponse(
    Guid Id,
    string SourceOrderType,
    Guid SourceOrderId,
    Guid MaterialId,
    Guid SiteId,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string QuantityUnitOfMeasure,
    string Status);