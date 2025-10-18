using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Application.PlanningAreas.Commands.Update;

internal sealed class UpdatePlanningAreaCommandHandler(
    IPlanningAreaRepository planningAreaRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePlanningAreaCommand, Result>
{
    public async Task<Result> Handle(
        UpdatePlanningAreaCommand request,
        CancellationToken cancellationToken)
    {
        var planningArea = await planningAreaRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningArea is null)
        {
            return Result.Failure(PlanningAreaErrors.NotFound);
        }

        planningArea.Update(
            request.PlanningAreaCode,
            request.Description,
            request.SiteId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}