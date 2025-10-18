namespace MaterialFlow.Application.PlannedProductionOrders.Commands.Cancel;

internal sealed class CancelPlannedProductionOrderCommandValidator : AbstractValidator<CancelPlannedProductionOrderCommand>
{
    public CancelPlannedProductionOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}