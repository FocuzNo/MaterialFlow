namespace MaterialFlow.Application.SalesOrderDemands.Commands.Delete;

internal sealed class DeleteSalesOrderDemandCommandValidator : AbstractValidator<DeleteSalesOrderDemandCommand>
{
    public DeleteSalesOrderDemandCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}