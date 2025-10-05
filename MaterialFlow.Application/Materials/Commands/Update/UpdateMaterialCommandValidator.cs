namespace MaterialFlow.Application.Materials.Commands.Update;

public sealed class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.MaterialNumber)
            .NotEmpty()
            .WithMessage("Material number is required.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(x => x.PlannedDeliveryTimeInDays)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Planned delivery time must be non-negative.");

        RuleFor(x => x.SafetyStockQuantity)
            .Must(q => q.Amount >= 0)
            .WithMessage("Safety stock quantity must be non-negative.");

        RuleFor(x => x.BaseUnitOfMeasure)
            .NotNull()
            .WithMessage("Base unit of measure is required.");

        RuleFor(x => x.MRPType)
            .NotNull()
            .WithMessage("MRP type is required.");

        RuleFor(x => x.LotSizePolicy)
            .NotNull()
            .WithMessage("Lot size policy is required.");

        RuleFor(x => x.ProcurementType)
            .NotNull()
            .WithMessage("Procurement type is required.");
    }
}