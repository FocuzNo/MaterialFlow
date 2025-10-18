namespace MaterialFlow.Application.PlanningRuns.Commands.Update;

internal sealed class UpdatePlanningRunCommandValidator : AbstractValidator<UpdatePlanningRunCommand>
{
    public UpdatePlanningRunCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.PlanningHorizonInDays)
            .GreaterThan(0)
            .WithMessage("Planning horizon must be greater than zero.")
            .LessThanOrEqualTo(365)
            .WithMessage("Planning horizon must not exceed 365 days.");

        RuleFor(x => x.OrderStatus)
            .GreaterThan(0)
            .WithMessage("Invalid order status.");
    }
}