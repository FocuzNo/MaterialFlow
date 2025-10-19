namespace MaterialFlow.Application.SalesOrderDemands.Commands.Create;

internal sealed class CreateSalesOrderDemandCommandValidator : AbstractValidator<CreateSalesOrderDemandCommand>
{
    public CreateSalesOrderDemandCommandValidator()
    {
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
            .WithMessage("Requirement date must be in the future or today.");

        RuleFor(x => x.QuantityAmount)
            .GreaterThan(0)
            .WithMessage("Quantity amount must be greater than zero.")
            .PrecisionScale(21, 3, true)
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

        RuleFor(x => x.SourceDocumentType)
            .NotEmpty()
            .WithMessage("Source document type is required.")
            .MaximumLength(50)
            .WithMessage("Source document type must not exceed 50 characters.");

        RuleFor(x => x.SourceDocumentNumber)
            .NotEmpty()
            .WithMessage("Source document number is required.")
            .MaximumLength(50)
            .WithMessage("Source document number must not exceed 50 characters.");

        RuleFor(x => x.SourceDocumentItemNumber)
            .NotEmpty()
            .WithMessage("Source document item number is required.")
            .MaximumLength(50)
            .WithMessage("Source document item number must not exceed 50 characters.");
    }
}