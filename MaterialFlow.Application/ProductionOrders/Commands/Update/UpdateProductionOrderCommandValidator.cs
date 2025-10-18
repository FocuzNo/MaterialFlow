namespace MaterialFlow.Application.ProductionOrders.Commands.Update;

internal sealed class UpdateProductionOrderCommandValidator : AbstractValidator<UpdateProductionOrderCommand>
{
    public UpdateProductionOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.QuantityToProduceAmount)
            .GreaterThan(0)
            .WithMessage("Quantity to produce must be greater than zero.");

        RuleFor(x => x.QuantityToProduceUnitOfMeasure)
            .NotEmpty()
            .WithMessage("Quantity to produce unit of measure is required.");

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