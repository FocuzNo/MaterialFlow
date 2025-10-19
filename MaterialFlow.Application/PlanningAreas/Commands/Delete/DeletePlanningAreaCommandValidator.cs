namespace MaterialFlow.Application.PlanningAreas.Commands.Delete;

internal sealed class DeletePlanningAreaCommandValidator : AbstractValidator<DeletePlanningAreaCommand>
{
    public DeletePlanningAreaCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}