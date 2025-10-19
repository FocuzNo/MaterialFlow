using MaterialFlow.Domain.PlanningRuns;

namespace MaterialFlow.Application.PlanningRuns.Queries.GetAll;

internal sealed class GetAllPlanningRunsQueryHandler(IPlanningRunRepository planningRunRepository)
    : IRequestHandler<GetAllPlanningRunsQuery, Result<IReadOnlyCollection<PlanningRunResponse>>>
{
    public async Task<Result<IReadOnlyCollection<PlanningRunResponse>>> Handle(
        GetAllPlanningRunsQuery request,
        CancellationToken cancellationToken)
    {
        var planningRuns = await planningRunRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<PlanningRunResponse>)[.. planningRuns
            .Select(x => new PlanningRunResponse(
                x.Id,
                x.RunTimestampUtc,
                x.SiteId,
                x.PlanningAreaId,
                x.PlanningHorizonInDays,
                x.StartedByUser,
                x.OrderStatus.Name,
                x.Lines.Count)
            )]);
    }
}