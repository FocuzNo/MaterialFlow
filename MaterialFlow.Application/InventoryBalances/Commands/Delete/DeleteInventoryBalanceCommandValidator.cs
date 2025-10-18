namespace MaterialFlow.Application.InventoryBalances.Commands.Delete;

internal sealed class DeleteInventoryBalanceCommandValidator : AbstractValidator<DeleteInventoryBalanceCommand>
{
    public DeleteInventoryBalanceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}