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

        RuleFor(x => x.StorageLocationId)
            .NotEmpty()
            .When(x => x.StorageLocationId.HasValue)
            .WithMessage("Storage location ID is invalid.");

        RuleFor(x => x.OnHandAmount)
            .GreaterThanOrEqualTo(0)
            .PrecisionScale(18, 3, true)
            .WithMessage("On-hand amount must be non-negative and within precision (18,3).");

        RuleFor(x => x.ReservedAmount)
            .GreaterThanOrEqualTo(0)
            .PrecisionScale(18, 3, true)
            .WithMessage("Reserved amount must be non-negative and within precision (18,3).");

        RuleFor(x => x.Batch)
            .MaximumLength(100)
            .WithMessage("Batch cannot exceed 100 characters.");
    }
}
