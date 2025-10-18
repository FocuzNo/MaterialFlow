namespace MaterialFlow.Application.ProductComponents.Commands.Create;

internal sealed class CreateProductComponentCommandValidator : AbstractValidator<CreateProductComponentCommand>
{
    public CreateProductComponentCommandValidator()
    {
        RuleFor(x => x.ProductStructureId)
            .NotEmpty()
            .WithMessage("Product structure ID is required.");

        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Unit of measure must not exceed 20 characters.");

        RuleFor(x => x.QuantityPerAmount)
            .GreaterThan(0)
            .WithMessage("Quantity per must be greater than zero.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Quantity per must have precision 18, scale 3.");

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