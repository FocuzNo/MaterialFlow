namespace MaterialFlow.Application.ProductComponents.Commands.Update;

internal sealed class UpdateProductComponentCommandValidator : AbstractValidator<UpdateProductComponentCommand>
{
    public UpdateProductComponentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Unit of measure must not exceed 20 characters.");

        RuleFor(x => x.QuantityPerAmount)
            .GreaterThan(0)
            .WithMessage("Quantity per must be greater than zero.");

        RuleFor(x => x.QuantityPerUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Quantity per unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Quantity per unit of measure must not exceed 20 characters.");

        RuleFor(x => x.ScrapPercentage)
            .InclusiveBetween(0, 100)
            .WithMessage("Scrap percentage must be between 0 and 100.")
            .When(x => x.ScrapPercentage.HasValue);
    }
}