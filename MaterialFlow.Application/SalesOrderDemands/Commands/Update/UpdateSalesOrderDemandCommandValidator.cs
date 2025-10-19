namespace MaterialFlow.Application.SalesOrderDemands.Commands.Update;

internal sealed class UpdateSalesOrderDemandCommandValidator : AbstractValidator<UpdateSalesOrderDemandCommand>
{
    public UpdateSalesOrderDemandCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.RequirementDate)
            .NotEmpty()
            .WithMessage("Requirement date is required.")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Requirement date must be in the future or today.");

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
    }
}