namespace MaterialFlow.Application.ForecastPlanItems.Commands.Create;

internal sealed class CreateForecastPlanItemCommandValidator : AbstractValidator<CreateForecastPlanItemCommand>
{
    public CreateForecastPlanItemCommandValidator()
    {
        RuleFor(x => x.ForecastPlanId)
            .NotEmpty()
            .WithMessage("Forecast plan ID is required.");

        RuleFor(x => x.PeriodStartDate)
            .NotEmpty()
            .WithMessage("Period start date is required.");

        RuleFor(x => x.QuantityAmount)
            .GreaterThan(0)
            .WithMessage("Quantity amount must be greater than zero.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Quantity amount must have precision 18, scale 3.");

        RuleFor(x => x.QuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Quantity unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Quantity unit of measure must not exceed 20 characters.");

        RuleFor(x => x.ConsumptionIndicator)
            .MaximumLength(50)
            .WithMessage("Consumption indicator must not exceed 50 characters.")
            .When(x => !string.IsNullOrEmpty(x.ConsumptionIndicator));
    }
}