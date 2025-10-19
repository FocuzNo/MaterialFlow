using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Application.PlanningAreas.Commands.Delete;

internal sealed class DeletePlanningAreaCommandHandler(
    IPlanningAreaRepository planningAreaRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeletePlanningAreaCommand, Result>
{
    public async Task<Result> Handle(
        DeletePlanningAreaCommand request,
        CancellationToken cancellationToken)
    {
        var planningArea = await planningAreaRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningArea is null)
        {
            return Result.Failure(PlanningAreaErrors.NotFound);
        }

        planningAreaRepository.Delete(planningArea);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}