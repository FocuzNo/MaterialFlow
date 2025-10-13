namespace MaterialFlow.Application.ForecastPlanItems.Commands.Update;

internal sealed class UpdateForecastPlanItemCommandValidator : AbstractValidator<UpdateForecastPlanItemCommand>
{
    public UpdateForecastPlanItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Quantity must be non-negative.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("UnitOfMeasure is required.");
    }
}