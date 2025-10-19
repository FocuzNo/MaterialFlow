using MaterialFlow.Domain.PlanningRuns;

namespace MaterialFlow.Application.PlanningRuns.Queries.GetById;

internal sealed class GetPlanningRunByIdQueryHandler(IPlanningRunRepository planningRunRepository)
    : IRequestHandler<GetPlanningRunByIdQuery, Result<PlanningRunResponse>>
{
    public async Task<Result<PlanningRunResponse>> Handle(
        GetPlanningRunByIdQuery request,
        CancellationToken cancellationToken)
    {
        var planningRun = await planningRunRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningRun is null)
        {
            return Result.Failure<PlanningRunResponse>(PlanningRunErrors.NotFound);
        }

        var response = new PlanningRunResponse(
            planningRun.Id,
            planningRun.RunTimestampUtc,
            planningRun.SiteId,
            planningRun.PlanningAreaId,
            planningRun.PlanningHorizonInDays,
            planningRun.StartedByUser,
            planningRun.OrderStatus.Name,
            planningRun.Lines.Count);

        return Result.Success(response);
    }
}