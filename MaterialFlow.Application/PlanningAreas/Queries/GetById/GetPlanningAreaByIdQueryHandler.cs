using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Application.PlanningAreas.Queries.GetById;

internal sealed class GetPlanningAreaByIdQueryHandler(IPlanningAreaRepository planningAreaRepository)
    : IRequestHandler<GetPlanningAreaByIdQuery, Result<PlanningAreaResponse>>
{
    public async Task<Result<PlanningAreaResponse>> Handle(
        GetPlanningAreaByIdQuery request,
        CancellationToken cancellationToken)
    {
        var planningArea = await planningAreaRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningArea is null)
        {
            return Result.Failure<PlanningAreaResponse>(PlanningAreaErrors.NotFound);
        }

        var response = new PlanningAreaResponse(
            planningArea.Id,
            planningArea.PlanningAreaCode,
            planningArea.Description,
            planningArea.SiteId);

        return Result.Success(response);
    }
}