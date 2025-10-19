using MaterialFlow.Domain.SalesOrderDemands;
using System.Linq;

namespace MaterialFlow.Application.SalesOrderDemands.Queries.GetAll;

internal sealed class GetAllSalesOrderDemandsQueryHandler(ISalesOrderDemandRepository salesOrderDemandRepository)
    : IRequestHandler<GetAllSalesOrderDemandsQuery, Result<IReadOnlyCollection<SalesOrderDemandResponse>>>
{
    public async Task<Result<IReadOnlyCollection<SalesOrderDemandResponse>>> Handle(
        GetAllSalesOrderDemandsQuery request,
        CancellationToken cancellationToken)
    {
        var salesOrderDemands = await salesOrderDemandRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<SalesOrderDemandResponse>)[.. salesOrderDemands
            .Select(x => new SalesOrderDemandResponse(
                x.Id,
                x.MaterialId,
                x.SiteId,
                x.RequirementDate,
                x.Quantity.Amount,
                x.Quantity.UnitOfMeasure.Value,
                x.UnitOfMeasure.Value,
                x.SourceDocument.Type,
                x.SourceDocument.Number,
                x.SourceDocument.ItemNumber)
            )]);
    }
}