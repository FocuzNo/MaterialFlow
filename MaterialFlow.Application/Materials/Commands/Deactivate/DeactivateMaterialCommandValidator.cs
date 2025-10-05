namespace MaterialFlow.Application.Materials.Commands.Deactivate;

public sealed class DeactivateMaterialCommandValidator : AbstractValidator<DeactivateMaterialCommand>
{
    public DeactivateMaterialCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}