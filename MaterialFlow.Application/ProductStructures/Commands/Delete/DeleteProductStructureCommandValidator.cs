namespace MaterialFlow.Application.ProductStructures.Commands.Delete;

internal sealed class DeleteProductStructureCommandValidator : AbstractValidator<DeleteProductStructureCommand>
{
    public DeleteProductStructureCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}