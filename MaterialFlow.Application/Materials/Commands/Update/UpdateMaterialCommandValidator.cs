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

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Base unit of measure is required.");

        RuleFor(x => x.MaterialRequirementsPlanningType)
            .GreaterThan(0)
            .WithMessage("Invalid MRP type.");

        RuleFor(x => x.LotSizePolicy)
            .GreaterThan(0)
            .WithMessage("Invalid lot size policy.");

        RuleFor(x => x.ProcurementType)
            .GreaterThan(0)
            .WithMessage("Invalid procurement type.");

        RuleFor(x => x.PlannedDeliveryTimeInDays)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Planned delivery time must be non-negative.");

        RuleFor(x => x.SafetyStockAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Safety stock amount must be non-negative.");

        RuleFor(x => x.SafetyStockUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Safety stock unit of measure is required.");
    }
}