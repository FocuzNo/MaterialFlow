using MaterialFlow.Domain.SalesOrderDemands;
using MaterialFlow.Domain.SalesOrderDemands.ValueObjects;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Application.SalesOrderDemands.Commands.Create;

internal sealed class CreateSalesOrderDemandCommandHandler(
    ISalesOrderDemandRepository salesOrderDemandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateSalesOrderDemandCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateSalesOrderDemandCommand request,
        CancellationToken cancellationToken)
    {
        var salesOrderDemand = SalesOrderDemand.Create(
            Guid.NewGuid(),
            request.MaterialId,
            request.SiteId,
            request.RequirementDate,
            new Quantity(
                request.QuantityAmount,
                new UnitOfMeasure(request.QuantityUnitOfMeasure)),
            new UnitOfMeasure(request.UnitOfMeasure),
            new SourceDocument(
                request.SourceDocumentType,
                request.SourceDocumentNumber,
                request.SourceDocumentItemNumber));

        await salesOrderDemandRepository.AddAsync(
            salesOrderDemand,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return salesOrderDemand.Id;
    }
}