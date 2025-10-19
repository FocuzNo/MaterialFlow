using MaterialFlow.Domain.PlanningRuns;

namespace MaterialFlow.Application.PlanningRuns.Commands.Delete;

internal sealed class DeletePlanningRunCommandHandler(
    IPlanningRunRepository planningRunRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeletePlanningRunCommand, Result>
{
    public async Task<Result> Handle(
        DeletePlanningRunCommand request,
        CancellationToken cancellationToken)
    {
        var planningRun = await planningRunRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningRun is null)
        {
            return Result.Failure(PlanningRunErrors.NotFound);
        }

        planningRunRepository.Delete(planningRun);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}