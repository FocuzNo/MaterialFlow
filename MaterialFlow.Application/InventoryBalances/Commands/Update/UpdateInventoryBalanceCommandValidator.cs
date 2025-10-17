namespace MaterialFlow.Application.InventoryBalances.Commands.Update;

internal sealed class UpdateInventoryBalanceCommandValidator : AbstractValidator<UpdateInventoryBalanceCommand>
{
    public UpdateInventoryBalanceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Inventory balance ID is required.");

        RuleFor(x => x.OnHandAmount)
            .GreaterThanOrEqualTo(0)
            .PrecisionScale(18, 3, true)
            .WithMessage("On-hand amount must be non-negative and within precision (18,3).");

        RuleFor(x => x.ReservedAmount)
            .GreaterThanOrEqualTo(0)
            .PrecisionScale(18, 3, true)
            .WithMessage("Reserved amount must be non-negative and within precision (18,3).");

        RuleFor(x => x.OnHandUnit)
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("On-hand unit of measure is required and must not exceed 20 characters.");

        RuleFor(x => x.ReservedUnit)
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("Reserved unit of measure is required and must not exceed 20 characters.");

        RuleFor(x => x.Batch)
            .MaximumLength(100)
            .WithMessage("Batch cannot exceed 100 characters.");
    }
}
