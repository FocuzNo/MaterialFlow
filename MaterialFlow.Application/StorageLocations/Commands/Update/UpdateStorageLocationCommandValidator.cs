namespace MaterialFlow.Application.StorageLocations.Commands.Update;

internal sealed class UpdateStorageLocationCommandValidator : AbstractValidator<UpdateStorageLocationCommand>
{
    public UpdateStorageLocationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .MaximumLength(20)
            .WithMessage("Code must not exceed 20 characters.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
    }
}