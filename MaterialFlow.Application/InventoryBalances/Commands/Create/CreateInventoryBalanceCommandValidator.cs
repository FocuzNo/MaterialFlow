namespace MaterialFlow.Application.InventoryBalances.Commands.Create;

internal sealed class CreateInventoryBalanceCommandValidator : AbstractValidator<CreateInventoryBalanceCommand>
{
    public CreateInventoryBalanceCommandValidator()
    {
        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.SiteId)
            .NotEmpty()
            .WithMessage("Site ID is required.");

        RuleFor(x => x.OnHandAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("On hand amount must be non-negative.")
            .PrecisionScale(21, 3, false)
            .WithMessage("On hand amount must have precision 18, scale 3.");

        RuleFor(x => x.OnHandUnitOfMeasure)
            .NotEmpty()
            .WithMessage("On hand unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("On hand unit of measure must not exceed 20 characters.");

        RuleFor(x => x.ReservedAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Reserved amount must be non-negative.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Reserved amount must have precision 18, scale 3.");

        RuleFor(x => x.ReservedUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Reserved unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Reserved unit of measure must not exceed 20 characters.");

        RuleFor(x => x.Batch)
            .MaximumLength(50)
            .WithMessage("Batch must not exceed 50 characters.")
            .When(x => !string.IsNullOrEmpty(x.Batch));

        RuleFor(x => x.ReservedAmount)
            .LessThanOrEqualTo(x => x.OnHandAmount)
            .WithMessage("Reserved amount cannot exceed on hand amount.");
    }
}