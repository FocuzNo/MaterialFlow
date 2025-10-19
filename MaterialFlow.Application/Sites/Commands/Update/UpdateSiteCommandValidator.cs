namespace MaterialFlow.Application.Sites.Commands.Update;

internal sealed class UpdateSiteCommandValidator : AbstractValidator<UpdateSiteCommand>
{
    public UpdateSiteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

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