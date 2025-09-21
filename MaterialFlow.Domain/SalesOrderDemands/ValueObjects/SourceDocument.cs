namespace MaterialFlow.Domain.SalesOrderDemands.ValueObjects;

public sealed record SourceDocument(
    string Type,
    string Number,
    string ItemNumber);
