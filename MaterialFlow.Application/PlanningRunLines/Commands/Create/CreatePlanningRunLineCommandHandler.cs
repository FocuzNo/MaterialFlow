using MaterialFlow.Domain.PlanningRunLines;

namespace MaterialFlow.Application.PlanningRunLines.Commands.Create;

internal sealed class CreatePlanningRunLineCommandHandler(
    IPlanningRunLineRepository planningRunLineRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePlanningRunLineCommand, Guid>
{
    public async Task<Guid> Handle(
        CreatePlanningRunLineCommand request,
        CancellationToken cancellationToken)
    {
        var planningRunLine = PlanningRunLine.Create(
            Guid.NewGuid(),
            request.PlanningRunId,
            request.MaterialId,
            request.SiteId,
            request.RequirementDate,
            new Quantity(
                request.RequirementQuantityAmount,
                new UnitOfMeasure(request.RequirementQuantityUnitOfMeasure)),
            new Quantity(
                request.AvailableQuantityAmount,
                new UnitOfMeasure(request.AvailableQuantityUnitOfMeasure)),
            new Quantity(
                request.ShortageQuantityAmount,
                new UnitOfMeasure(request.ShortageQuantityUnitOfMeasure)),
            request.RecommendedAction,
            request.RescheduleDate ?? request.RequirementDate);

        await planningRunLineRepository.AddAsync(
            planningRunLine,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return planningRunLine.Id;
    }
}