namespace MaterialFlow.Application.ForecastPlans.Commands.Create;

internal sealed class CreateForecastPlanCommandValidator : AbstractValidator<CreateForecastPlanCommand>
{
    public CreateForecastPlanCommandValidator()
    {
        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.Version)
            .NotEmpty()
            .WithMessage("Version is required.")
            .MaximumLength(50)
            .WithMessage("Version must not exceed 50 characters.");

        RuleFor(x => x.PlanningStrategy)
            .NotEmpty()
            .WithMessage("Planning strategy is required.")
            .MaximumLength(50)
            .WithMessage("Planning strategy must not exceed 50 characters.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Unit of measure must not exceed 20 characters.");

        RuleFor(x => x.PeriodGranularity)
            .GreaterThan(0)
            .WithMessage("Invalid period granularity.");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be greater than start date.");
    }
}
