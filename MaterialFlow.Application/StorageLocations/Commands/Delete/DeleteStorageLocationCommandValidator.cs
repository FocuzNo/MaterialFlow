namespace MaterialFlow.Application.StorageLocations.Commands.Delete;

internal sealed class DeleteStorageLocationCommandValidator : AbstractValidator<DeleteStorageLocationCommand>
{
    public DeleteStorageLocationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}