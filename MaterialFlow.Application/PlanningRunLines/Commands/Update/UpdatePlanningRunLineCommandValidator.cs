namespace MaterialFlow.Application.PlanningRunLines.Commands.Update;

internal sealed class UpdatePlanningRunLineCommandValidator : AbstractValidator<UpdatePlanningRunLineCommand>
{
    public UpdatePlanningRunLineCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.RequirementDate)
            .NotEmpty()
            .WithMessage("Requirement date is required.");

        RuleFor(x => x.RequirementQuantityAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Requirement quantity amount must be non-negative.");

        RuleFor(x => x.RequirementQuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Requirement quantity unit of measure is required.");

        RuleFor(x => x.AvailableQuantityAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Available quantity amount must be non-negative.");

        RuleFor(x => x.AvailableQuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Available quantity unit of measure is required.");

        RuleFor(x => x.ShortageQuantityAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Shortage quantity amount must be non-negative.");

        RuleFor(x => x.ShortageQuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Shortage quantity unit of measure is required.");

        RuleFor(x => x.RecommendedAction)
            .NotEmpty()
            .WithMessage("Recommended action is required.")
            .MaximumLength(100)
            .WithMessage("Recommended action must not exceed 100 characters.");
    }
}