namespace MaterialFlow.Application.PlanningRunLines.Commands.Update;

public sealed record UpdatePlanningRunLineCommand(
    Guid Id,
    DateOnly RequirementDate,
    decimal RequirementQuantityAmount,
    string RequirementQuantityUnitOfMeasure,
    decimal AvailableQuantityAmount,
    string AvailableQuantityUnitOfMeasure,
    decimal ShortageQuantityAmount,
    string ShortageQuantityUnitOfMeasure,
    string RecommendedAction,
    DateOnly? RescheduleDate) : IRequest<Result>;