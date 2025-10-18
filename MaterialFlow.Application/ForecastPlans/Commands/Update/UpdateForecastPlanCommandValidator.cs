namespace MaterialFlow.Application.ForecastPlans.Commands.Update;

internal sealed class UpdateForecastPlanCommandValidator : AbstractValidator<UpdateForecastPlanCommand>
{
    public UpdateForecastPlanCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

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
            .WithMessage("Unit of measure is required.");

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