using MaterialFlow.Domain.SalesOrderDemands;

namespace MaterialFlow.Application.SalesOrderDemands.Queries.GetById;

internal sealed class GetSalesOrderDemandByIdQueryHandler(ISalesOrderDemandRepository salesOrderDemandRepository)
    : IRequestHandler<GetSalesOrderDemandByIdQuery, Result<SalesOrderDemandResponse>>
{
    public async Task<Result<SalesOrderDemandResponse>> Handle(
        GetSalesOrderDemandByIdQuery request,
        CancellationToken cancellationToken)
    {
        var salesOrderDemand = await salesOrderDemandRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (salesOrderDemand is null)
        {
            return Result.Failure<SalesOrderDemandResponse>(SalesOrderDemandErrors.NotFound);
        }

        var response = new SalesOrderDemandResponse(
            salesOrderDemand.Id,
            salesOrderDemand.MaterialId,
            salesOrderDemand.SiteId,
            salesOrderDemand.RequirementDate,
            salesOrderDemand.Quantity.Amount,
            salesOrderDemand.Quantity.UnitOfMeasure.Value,
            salesOrderDemand.UnitOfMeasure.Value,
            salesOrderDemand.SourceDocument.Type,
            salesOrderDemand.SourceDocument.Number,
            salesOrderDemand.SourceDocument.ItemNumber);

        return Result.Success(response);
    }
}