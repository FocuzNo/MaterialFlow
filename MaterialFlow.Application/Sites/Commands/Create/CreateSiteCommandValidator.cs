namespace MaterialFlow.Application.Sites.Commands.Create;

internal sealed class CreateSiteCommandValidator : AbstractValidator<CreateSiteCommand>
{
    public CreateSiteCommandValidator()
    {
        RuleFor(x => x.PlantCode)
            .NotEmpty()
            .WithMessage("Plant code is required.")
            .MaximumLength(10)
            .WithMessage("Plant code must not exceed 10 characters.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
    }
}