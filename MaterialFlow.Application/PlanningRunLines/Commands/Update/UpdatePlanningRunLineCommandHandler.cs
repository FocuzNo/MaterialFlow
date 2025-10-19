using MaterialFlow.Domain.PlanningRunLines;

namespace MaterialFlow.Application.PlanningRunLines.Commands.Update;

internal sealed class UpdatePlanningRunLineCommandHandler(
    IPlanningRunLineRepository planningRunLineRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePlanningRunLineCommand, Result>
{
    public async Task<Result> Handle(
        UpdatePlanningRunLineCommand request,
        CancellationToken cancellationToken)
    {
        var planningRunLine = await planningRunLineRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningRunLine is null)
        {
            return Result.Failure(PlanningRunLineErrors.NotFound);
        }

        planningRunLine.Update(
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

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}