using MaterialFlow.Domain.PlanningRunLines;

namespace MaterialFlow.Application.PlanningRunLines.Commands.Delete;

internal sealed class DeletePlanningRunLineCommandHandler(
    IPlanningRunLineRepository planningRunLineRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeletePlanningRunLineCommand, Result>
{
    public async Task<Result> Handle(
        DeletePlanningRunLineCommand request,
        CancellationToken cancellationToken)
    {
        var planningRunLine = await planningRunLineRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (planningRunLine is null)
        {
            return Result.Failure(PlanningRunLineErrors.NotFound);
        }

        planningRunLineRepository.Delete(planningRunLine);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}