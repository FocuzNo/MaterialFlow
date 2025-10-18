namespace MaterialFlow.Application.PlanningRunLines.Commands.Delete;

internal sealed class DeletePlanningRunLineCommandValidator : AbstractValidator<DeletePlanningRunLineCommand>
{
    public DeletePlanningRunLineCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}