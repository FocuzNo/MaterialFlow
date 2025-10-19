namespace MaterialFlow.Application.ProductStructures.Commands.Update;

internal sealed class UpdateProductStructureCommandValidator : AbstractValidator<UpdateProductStructureCommand>
{
    public UpdateProductStructureCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.Usage)
            .GreaterThan(0)
            .WithMessage("Invalid BOM usage.");

        RuleFor(x => x.AlternativeNumber)
            .MaximumLength(10)
            .WithMessage("Alternative number must not exceed 10 characters.")
            .When(x => !string.IsNullOrEmpty(x.AlternativeNumber));

        RuleFor(x => x.ValidFromDate)
            .NotEmpty()
            .WithMessage("Valid from date is required.");

        RuleFor(x => x.ValidToDate)
            .GreaterThan(x => x.ValidFromDate)
            .WithMessage("Valid to date must be greater than valid from date.")
            .When(x => x.ValidToDate.HasValue);

        RuleFor(x => x.OrderStatus)
            .GreaterThan(0)
            .WithMessage("Invalid order status.");
    }
}