using MaterialFlow.Domain.SalesOrderDemands;

namespace MaterialFlow.Application.SalesOrderDemands.Commands.Delete;

internal sealed class DeleteSalesOrderDemandCommandHandler(
    ISalesOrderDemandRepository salesOrderDemandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteSalesOrderDemandCommand, Result>
{
    public async Task<Result> Handle(
        DeleteSalesOrderDemandCommand request,
        CancellationToken cancellationToken)
    {
        var salesOrderDemand = await salesOrderDemandRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (salesOrderDemand is null)
        {
            return Result.Failure(SalesOrderDemandErrors.NotFound);
        }

        salesOrderDemandRepository.Delete(salesOrderDemand);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}