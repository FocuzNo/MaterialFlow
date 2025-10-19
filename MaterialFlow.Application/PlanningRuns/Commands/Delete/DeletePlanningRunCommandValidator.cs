namespace MaterialFlow.Application.PlanningRuns.Commands.Delete;

internal sealed class DeletePlanningRunCommandValidator : AbstractValidator<DeletePlanningRunCommand>
{
    public DeletePlanningRunCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}