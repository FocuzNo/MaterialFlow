namespace MaterialFlow.Application.PlanningRunLines.Commands.Create;

public sealed record CreatePlanningRunLineCommand(
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
    DateOnly? RescheduleDate) : IRequest<Guid>;