namespace MaterialFlow.Application.InventoryBalances.Commands.Update;

internal sealed class UpdateInventoryBalanceCommandValidator : AbstractValidator<UpdateInventoryBalanceCommand>
{
    public UpdateInventoryBalanceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.OnHandAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("On hand amount must be non-negative.");

        RuleFor(x => x.OnHandUnitOfMeasure)
            .NotEmpty()
            .WithMessage("On hand unit of measure is required.");

        RuleFor(x => x.ReservedAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Reserved amount must be non-negative.");

        RuleFor(x => x.ReservedUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Reserved unit of measure is required.");

        RuleFor(x => x.Batch)
            .MaximumLength(50)
            .WithMessage("Batch must not exceed 50 characters.")
            .When(x => !string.IsNullOrEmpty(x.Batch));

        RuleFor(x => x.ReservedAmount)
            .LessThanOrEqualTo(x => x.OnHandAmount)
            .WithMessage("Reserved amount cannot exceed on hand amount.");
    }
}