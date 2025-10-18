namespace MaterialFlow.Application.Materials.Commands.Create;

internal sealed class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(x => x.MaterialNumber)
            .NotEmpty()
            .WithMessage("Material number is required.")
            .MaximumLength(50)
            .WithMessage("Material number must not exceed 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(250)
            .WithMessage("Description must not exceed 250 characters.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Base unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Unit of measure must not exceed 20 characters.");

        RuleFor(x => x.MaterialRequirementsPlanningType)
            .GreaterThan(0)
            .WithMessage("Invalid Material Requirements Planning type.");

        RuleFor(x => x.LotSizePolicy)
            .GreaterThan(0)
            .WithMessage("Invalid Lot Size Policy.");

        RuleFor(x => x.ProcurementType)
            .GreaterThan(0)
            .WithMessage("Invalid Procurement Type.");

        RuleFor(x => x.PlannedDeliveryTimeInDays)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Planned delivery time must be non-negative.");

        RuleFor(x => x.SafetyStockAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Safety stock amount must be non-negative.")
            .PrecisionScale(18, 3, true)
            .WithMessage("Safety stock amount must have precision 18 and scale 3.");

        RuleFor(x => x.SafetyStockUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Safety stock unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Safety stock unit of measure must not exceed 20 characters.");
    }
}