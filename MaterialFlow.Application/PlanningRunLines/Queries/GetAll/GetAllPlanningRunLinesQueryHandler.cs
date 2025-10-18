using MaterialFlow.Domain.PlanningRunLines;

namespace MaterialFlow.Application.PlanningRunLines.Queries.GetAll;

internal sealed class GetAllPlanningRunLinesQueryHandler(IPlanningRunLineRepository planningRunLineRepository)
    : IRequestHandler<GetAllPlanningRunLinesQuery, Result<IReadOnlyCollection<PlanningRunLineResponse>>>
{
    public async Task<Result<IReadOnlyCollection<PlanningRunLineResponse>>> Handle(
        GetAllPlanningRunLinesQuery request,
        CancellationToken cancellationToken)
    {
        var planningRunLines = await planningRunLineRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<PlanningRunLineResponse>)[.. planningRunLines
            .Select(x => new PlanningRunLineResponse(
                x.Id,
                x.PlanningRunId,
                x.MaterialId,
                x.SiteId,
                x.RequirementDate,
                x.RequirementQuantity.Amount,
                x.RequirementQuantity.UnitOfMeasure.Value,
                x.AvailableQuantity.Amount,
                x.AvailableQuantity.UnitOfMeasure.Value,
                x.ShortageQuantity.Amount,
                x.ShortageQuantity.UnitOfMeasure.Value,
                x.RecommendedAction,
                x.RescheduleDate)
            )]);
    }
}