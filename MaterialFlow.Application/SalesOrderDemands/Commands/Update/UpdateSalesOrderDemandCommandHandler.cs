using MaterialFlow.Domain.SalesOrderDemands;

namespace MaterialFlow.Application.SalesOrderDemands.Commands.Update;

internal sealed class UpdateSalesOrderDemandCommandHandler(
    ISalesOrderDemandRepository salesOrderDemandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateSalesOrderDemandCommand, Result>
{
    public async Task<Result> Handle(
        UpdateSalesOrderDemandCommand request,
        CancellationToken cancellationToken)
    {
        var salesOrderDemand = await salesOrderDemandRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (salesOrderDemand is null)
        {
            return Result.Failure(SalesOrderDemandErrors.NotFound);
        }

        salesOrderDemand.Update(
            request.RequirementDate,
            new Quantity(
                request.QuantityAmount,
                new UnitOfMeasure(request.QuantityUnitOfMeasure)),
            new UnitOfMeasure(request.UnitOfMeasure));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}