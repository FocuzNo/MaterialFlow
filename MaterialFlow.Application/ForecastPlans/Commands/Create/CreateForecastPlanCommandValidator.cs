namespace MaterialFlow.Application.ForecastPlans.Commands.Create;

internal sealed class CreateForecastPlanCommandValidator : AbstractValidator<CreateForecastPlanCommand>
{
    public CreateForecastPlanCommandValidator()
    {
        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("MaterialId is required.");

        RuleFor(x => x.Version)
            .NotEmpty()
            .WithMessage("Version is required.");

        RuleFor(x => x.PlanningStrategy)
            .NotEmpty()
            .WithMessage("PlanningStrategy is required.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("UnitOfMeasure is required.");

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("StartDate must be before or equal to EndDate.");
    }
}
