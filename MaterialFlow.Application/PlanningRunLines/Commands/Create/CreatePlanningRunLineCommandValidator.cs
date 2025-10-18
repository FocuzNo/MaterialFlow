namespace MaterialFlow.Application.PlanningRunLines.Commands.Create;

internal sealed class CreatePlanningRunLineCommandValidator : AbstractValidator<CreatePlanningRunLineCommand>
{
    public CreatePlanningRunLineCommandValidator()
    {
        RuleFor(x => x.PlanningRunId)
            .NotEmpty()
            .WithMessage("Planning run ID is required.");

        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.SiteId)
            .NotEmpty()
            .WithMessage("Site ID is required.");

        RuleFor(x => x.RequirementDate)
            .NotEmpty()
            .WithMessage("Requirement date is required.");

        RuleFor(x => x.RequirementQuantityAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Requirement quantity amount must be non-negative.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Requirement quantity amount must have precision 18, scale 3.");

        RuleFor(x => x.RequirementQuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Requirement quantity unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Requirement quantity unit of measure must not exceed 20 characters.");

        RuleFor(x => x.AvailableQuantityAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Available quantity amount must be non-negative.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Available quantity amount must have precision 18, scale 3.");

        RuleFor(x => x.AvailableQuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Available quantity unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Available quantity unit of measure must not exceed 20 characters.");

        RuleFor(x => x.ShortageQuantityAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Shortage quantity amount must be non-negative.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Shortage quantity amount must have precision 18, scale 3.");

        RuleFor(x => x.ShortageQuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Shortage quantity unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Shortage quantity unit of measure must not exceed 20 characters.");

        RuleFor(x => x.RecommendedAction)
            .NotEmpty()
            .WithMessage("Recommended action is required.")
            .MaximumLength(100)
            .WithMessage("Recommended action must not exceed 100 characters.");
    }
}