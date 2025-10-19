using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Application.PlanningAreas.Commands.Create;

internal sealed class CreatePlanningAreaCommandHandler(
    IPlanningAreaRepository planningAreaRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePlanningAreaCommand, Guid>
{
    public async Task<Guid> Handle(
        CreatePlanningAreaCommand request,
        CancellationToken cancellationToken)
    {
        var planningArea = PlanningArea.Create(
            Guid.NewGuid(),
            request.PlanningAreaCode,
            request.Description,
            request.SiteId);

        await planningAreaRepository.AddAsync(
            planningArea,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return planningArea.Id;
    }
}