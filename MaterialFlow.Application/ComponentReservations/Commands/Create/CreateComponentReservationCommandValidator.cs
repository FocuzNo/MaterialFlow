namespace MaterialFlow.Application.ComponentReservations.Commands.Create;

internal sealed class CreateComponentReservationCommandValidator : AbstractValidator<CreateComponentReservationCommand>
{
    public CreateComponentReservationCommandValidator()
    {
        RuleFor(x => x.SourceOrderType)
            .NotEmpty()
            .WithMessage("Source order type is required.")
            .MaximumLength(50)
            .WithMessage("Source order type must not exceed 50 characters.");

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
            .WithMessage("Requirement date is required.")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Requirement date must not be in the past.");

        RuleFor(x => x.QuantityAmount)
            .GreaterThan(0)
            .WithMessage("Quantity amount must be greater than zero.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Quantity amount must have precision 18, scale 3.");

        RuleFor(x => x.QuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Quantity unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Quantity unit of measure must not exceed 20 characters.");

        RuleFor(x => x.Status)
            .GreaterThan(0)
            .WithMessage("Invalid reservation status.");
    }
}