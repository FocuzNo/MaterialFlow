namespace MaterialFlow.Application.ProductStructures.Commands.AddComponent;

internal sealed class AddProductComponentCommandValidator : AbstractValidator<AddProductComponentCommand>
{
    public AddProductComponentCommandValidator()
    {
        RuleFor(x => x.ProductStructureId)
            .NotEmpty()
            .WithMessage("Product structure ID is required.");

        RuleFor(x => x.ComponentMaterialId)
            .NotEmpty()
            .WithMessage("Component material ID is required.");

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
            .WithMessage("Quantity per unit of measure is required.");

        RuleFor(x => x.ScrapPercentage)
            .InclusiveBetween(0, 100)
            .WithMessage("Scrap percentage must be between 0 and 100.")
            .When(x => x.ScrapPercentage.HasValue);
    }
}