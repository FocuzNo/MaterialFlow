using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Application.PlanningAreas.Queries.GetAll;

internal sealed class GetAllPlanningAreasQueryHandler(IPlanningAreaRepository planningAreaRepository)
    : IRequestHandler<GetAllPlanningAreasQuery, Result<IReadOnlyCollection<PlanningAreaResponse>>>
{
    public async Task<Result<IReadOnlyCollection<PlanningAreaResponse>>> Handle(
        GetAllPlanningAreasQuery request,
        CancellationToken cancellationToken)
    {
        var planningAreas = await planningAreaRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<PlanningAreaResponse>)[.. planningAreas
            .Select(x => new PlanningAreaResponse(
                x.Id,
                x.PlanningAreaCode,
                x.Description,
                x.SiteId)
            )]);
    }
}