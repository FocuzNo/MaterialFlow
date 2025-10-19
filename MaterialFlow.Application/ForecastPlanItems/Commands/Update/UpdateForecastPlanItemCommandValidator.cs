namespace MaterialFlow.Application.ForecastPlanItems.Commands.Update;

internal sealed class UpdateForecastPlanItemCommandValidator : AbstractValidator<UpdateForecastPlanItemCommand>
{
    public UpdateForecastPlanItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.PeriodStartDate)
            .NotEmpty()
            .WithMessage("Period start date is required.");

        RuleFor(x => x.QuantityAmount)
            .GreaterThan(0)
            .WithMessage("Quantity amount must be greater than zero.");

        RuleFor(x => x.QuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Quantity unit of measure is required.");

        RuleFor(x => x.ConsumptionIndicator)
            .MaximumLength(50)
            .WithMessage("Consumption indicator must not exceed 50 characters.")
            .When(x => !string.IsNullOrEmpty(x.ConsumptionIndicator));
    }
}