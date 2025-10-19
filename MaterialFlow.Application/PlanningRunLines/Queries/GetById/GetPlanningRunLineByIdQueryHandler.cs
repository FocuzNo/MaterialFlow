using MaterialFlow.Domain.PlanningRunLines;

namespace MaterialFlow.Application.PlanningRunLines.Queries.GetById;

internal sealed class GetPlanningRunLineByIdQueryHandler(IPlanningRunLineRepository planningRunLineRepository)
    : IRequestHandler<GetPlanningRunLineByIdQuery, Result<PlanningRunLineResponse>>
{
    public async Task<Result<PlanningRunLineResponse>> Handle(
        GetPlanningRunLineByIdQuery request,
        CancellationToken cancellationToken)
    {
        var planningRunLine = await planningRunLineRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningRunLine is null)
        {
            return Result.Failure<PlanningRunLineResponse>(PlanningRunLineErrors.NotFound);
        }

        var response = new PlanningRunLineResponse(
            planningRunLine.Id,
            planningRunLine.PlanningRunId,
            planningRunLine.MaterialId,
            planningRunLine.SiteId,
            planningRunLine.RequirementDate,
            planningRunLine.RequirementQuantity.Amount,
            planningRunLine.RequirementQuantity.UnitOfMeasure.Value,
            planningRunLine.AvailableQuantity.Amount,
            planningRunLine.AvailableQuantity.UnitOfMeasure.Value,
            planningRunLine.ShortageQuantity.Amount,
            planningRunLine.ShortageQuantity.UnitOfMeasure.Value,
            planningRunLine.RecommendedAction,
            planningRunLine.RescheduleDate);

        return Result.Success(response);
    }
}