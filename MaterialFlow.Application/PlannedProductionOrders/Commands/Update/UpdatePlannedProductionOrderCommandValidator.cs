namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Update;

internal sealed class UpdatePlannedProductionOrderCommandValidator : AbstractValidator<UpdatePlannedProductionOrderCommand>
{
    public UpdatePlannedProductionOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be greater than start date.");

        RuleFor(x => x.OrderStatus)
            .GreaterThan(0)
            .WithMessage("Invalid order status.");
    }
}