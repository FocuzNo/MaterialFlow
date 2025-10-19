namespace MaterialFlow.Application.PurchaseRequests.Commands.Create;

internal sealed class CreatePurchaseRequestCommandValidator : AbstractValidator<CreatePurchaseRequestCommand>
{
    public CreatePurchaseRequestCommandValidator()
    {
        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.SiteId)
            .NotEmpty()
            .WithMessage("Site ID is required.");

        RuleFor(x => x.QuantityAmount)
            .GreaterThan(0)
            .WithMessage("Quantity amount must be greater than zero.")
            .PrecisionScale(18, 3, true)
            .WithMessage("Quantity amount must have precision 18 and scale 3.");

        RuleFor(x => x.QuantityUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Quantity unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Quantity unit of measure must not exceed 20 characters.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Unit of measure must not exceed 20 characters.");

        RuleFor(x => x.RequestedDeliveryDate)
            .NotEmpty()
            .WithMessage("Requested delivery date is required.")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Requested delivery date must be in the future or today.");

        RuleFor(x => x.PurchasingGroup)
            .MaximumLength(50)
            .WithMessage("Purchasing group must not exceed 50 characters.")
            .When(x => !string.IsNullOrEmpty(x.PurchasingGroup));

        RuleFor(x => x.OrderStatus)
            .GreaterThan(0)
            .WithMessage("Invalid Order Status.");
    }
}