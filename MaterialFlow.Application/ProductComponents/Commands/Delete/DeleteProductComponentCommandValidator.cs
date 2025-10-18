namespace MaterialFlow.Application.ProductComponents.Commands.Delete;

internal sealed class DeleteProductComponentCommandValidator : AbstractValidator<DeleteProductComponentCommand>
{
    public DeleteProductComponentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}