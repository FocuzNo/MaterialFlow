using MaterialFlow.Domain.PlanningRuns;

namespace MaterialFlow.Application.PlanningRuns.Commands.Create;

internal sealed class CreatePlanningRunCommandHandler(
    IPlanningRunRepository planningRunRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePlanningRunCommand, Guid>
{
    public async Task<Guid> Handle(
        CreatePlanningRunCommand request,
        CancellationToken cancellationToken)
    {
        var planningRun = PlanningRun.Create(
            Guid.NewGuid(),
            DateTime.UtcNow,
            request.SiteId,
            request.PlanningAreaId,
            request.PlanningHorizonInDays,
            request.StartedByUser,
            OrderStatus.FromValue(request.OrderStatus));

        await planningRunRepository.AddAsync(
            planningRun,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return planningRun.Id;
    }
}