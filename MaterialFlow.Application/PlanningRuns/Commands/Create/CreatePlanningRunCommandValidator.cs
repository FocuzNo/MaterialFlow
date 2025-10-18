namespace MaterialFlow.Application.PlanningRuns.Commands.Create;

internal sealed class CreatePlanningRunCommandValidator : AbstractValidator<CreatePlanningRunCommand>
{
    public CreatePlanningRunCommandValidator()
    {
        RuleFor(x => x.PlanningHorizonInDays)
            .GreaterThan(0)
            .WithMessage("Planning horizon must be greater than zero.")
            .LessThanOrEqualTo(365)
            .WithMessage("Planning horizon must not exceed 365 days.");

        RuleFor(x => x.StartedByUser)
            .NotEmpty()
            .WithMessage("Started by user is required.")
            .MaximumLength(100)
            .WithMessage("Started by user must not exceed 100 characters.");

        RuleFor(x => x.OrderStatus)
            .GreaterThan(0)
            .WithMessage("Invalid order status.");
    }
}