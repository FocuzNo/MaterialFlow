namespace MaterialFlow.Application.PlanningRunLines.Queries;

public sealed record PlanningRunLineResponse(
    Guid Id,
    Guid PlanningRunId,
    Guid MaterialId,
    Guid SiteId,
    DateOnly RequirementDate,
    decimal RequirementQuantityAmount,
    string RequirementQuantityUnitOfMeasure,
    decimal AvailableQuantityAmount,
    string AvailableQuantityUnitOfMeasure,
    decimal ShortageQuantityAmount,
    string ShortageQuantityUnitOfMeasure,
    string RecommendedAction,
    DateOnly? RescheduleDate);