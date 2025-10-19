namespace MaterialFlow.Application.PurchaseRequests.Commands.Delete;

internal sealed class DeletePurchaseRequestCommandValidator : AbstractValidator<DeletePurchaseRequestCommand>
{
    public DeletePurchaseRequestCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}