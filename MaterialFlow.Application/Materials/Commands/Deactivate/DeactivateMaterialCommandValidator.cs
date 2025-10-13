namespace MaterialFlow.Application.Materials.Commands.Deactivate;

internal sealed class DeactivateMaterialCommandValidator : AbstractValidator<DeactivateMaterialCommand>
{
    public DeactivateMaterialCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}