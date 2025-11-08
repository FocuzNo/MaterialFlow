namespace MaterialFlow.Application.StorageLocations.Commands.Create;

internal sealed class CreateStorageLocationCommandValidator : AbstractValidator<CreateStorageLocationCommand>
{
    public CreateStorageLocationCommandValidator()
    {
        RuleFor(x => x.SiteId)
            .NotEmpty()
            .WithMessage("Site ID is required.");

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