namespace MaterialFlow.Application.ForecastPlanItems.Commands.Create;

internal sealed class CreateForecastPlanItemCommandValidator : AbstractValidator<CreateForecastPlanItemCommand>
{
    public CreateForecastPlanItemCommandValidator()
    {
        RuleFor(x => x.ForecastPlanId)
            .NotEmpty()
            .WithMessage("ForecastPlanId is required.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Quantity must be non-negative.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("UnitOfMeasure is required.");
    }
}