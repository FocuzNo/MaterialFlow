using MaterialFlow.Domain.PlanningRuns;

namespace MaterialFlow.Application.PlanningRuns.Commands.Update;

internal sealed class UpdatePlanningRunCommandHandler(
    IPlanningRunRepository planningRunRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePlanningRunCommand, Result>
{
    public async Task<Result> Handle(
        UpdatePlanningRunCommand request,
        CancellationToken cancellationToken)
    {
        var planningRun = await planningRunRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningRun is null)
        {
            return Result.Failure(PlanningRunErrors.NotFound);
        }

        planningRun.Update(
            request.PlanningHorizonInDays,
            OrderStatus.FromValue(request.OrderStatus));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}