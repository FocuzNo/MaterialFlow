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
