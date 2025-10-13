namespace MaterialFlow.Application.ComponentReservations.Queries.GetById;

public sealed record ComponentReservationResponse(
    Guid Id,
    string SourceOrderType,
    Guid SourceOrderId,
    Guid MaterialId,
    string MaterialNumber,
    Guid SiteId,
    string SiteName,
    DateOnly RequirementDate,
    decimal QuantityAmount,
    string UnitOfMeasure,
    string Status);