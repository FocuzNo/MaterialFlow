namespace MaterialFlow.Application.ProductStructures.Commands.RemoveComponent;

internal sealed class RemoveProductComponentCommandValidator : AbstractValidator<RemoveProductComponentCommand>
{
    public RemoveProductComponentCommandValidator()
    {
        RuleFor(x => x.ProductStructureId)
            .NotEmpty()
            .WithMessage("Product structure ID is required.");

        RuleFor(x => x.ComponentId)
            .NotEmpty()
            .WithMessage("Component ID is required.");
    }
}