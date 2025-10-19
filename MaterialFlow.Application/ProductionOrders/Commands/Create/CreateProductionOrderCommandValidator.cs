namespace MaterialFlow.Application.ProductionOrders.Commands.Create;

internal sealed class CreateProductionOrderCommandValidator : AbstractValidator<CreateProductionOrderCommand>
{
    public CreateProductionOrderCommandValidator()
    {
        RuleFor(x => x.MaterialId)
            .NotEmpty()
            .WithMessage("Material ID is required.");

        RuleFor(x => x.SiteId)
            .NotEmpty()
            .WithMessage("Site ID is required.");

        RuleFor(x => x.QuantityToProduceAmount)
            .GreaterThan(0)
            .WithMessage("Quantity to produce must be greater than zero.")
            .PrecisionScale(21, 3, false)
            .WithMessage("Quantity to produce must have precision 18, scale 3.");

        RuleFor(x => x.QuantityToProduceUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Quantity to produce unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Quantity to produce unit of measure must not exceed 20 characters.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Unit of measure is required.")
            .MaximumLength(20)
            .WithMessage("Unit of measure must not exceed 20 characters.");

        RuleFor(x => x.ScheduledStartDate)
            .NotEmpty()
            .WithMessage("Scheduled start date is required.");

        RuleFor(x => x.ScheduledEndDate)
            .NotEmpty()
            .WithMessage("Scheduled end date is required.")
            .GreaterThan(x => x.ScheduledStartDate)
            .WithMessage("Scheduled end date must be greater than scheduled start date.");

        RuleFor(x => x.OrderStatus)
            .GreaterThan(0)
            .WithMessage("Invalid order status.");
    }
}