namespace MaterialFlow.Application.PlanningAreas.Commands.Update;

internal sealed class UpdatePlanningAreaCommandValidator : AbstractValidator<UpdatePlanningAreaCommand>
{
    public UpdatePlanningAreaCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.PlanningAreaCode)
            .NotEmpty()
            .WithMessage("Planning area code is required.")
            .MaximumLength(50)
            .WithMessage("Planning area code must not exceed 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(250)
            .WithMessage("Description must not exceed 250 characters.");

        RuleFor(x => x.SiteId)
            .NotEmpty()
            .WithMessage("Site ID is required.");
    }
}