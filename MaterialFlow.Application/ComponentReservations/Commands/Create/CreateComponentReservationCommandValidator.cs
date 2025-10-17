namespace MaterialFlow.Application.ComponentReservations.Commands.Create;

public sealed class CreateComponentReservationCommandValidator : AbstractValidator<CreateComponentReservationCommand>
{
    public CreateComponentReservationCommandValidator()
    {
        RuleFor(x => x.SourceOrderType)
            .NotEmpty()
            .WithMessage("Source order type is required.");

        RuleFor(x => x.SourceOrderId)
            .NotEmpty()
            .WithMessage("Source order ID is required.");

        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.SiteId)
            .NotEmpty()
            .WithMessage("Site ID is required.");

        RuleFor(x => x.RequirementDate)
            .NotEmpty()
            .WithMessage("Requirement date is required.");

        RuleFor(x => x.QuantityAmount)
            .GreaterThan(0)
            .WithMessage("Quantity amount must be greater than zero.");

        RuleFor(x => x.Status)
            .GreaterThan(0)
            .WithMessage("Invalid status.");
    }
}
