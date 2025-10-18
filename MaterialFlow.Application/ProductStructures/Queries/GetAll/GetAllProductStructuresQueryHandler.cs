using MaterialFlow.Domain.ProductStructures;

namespace MaterialFlow.Application.ProductStructures.Queries.GetAll;

internal sealed class GetAllProductStructuresQueryHandler(IProductStructureRepository productStructureRepository)
    : IRequestHandler<GetAllProductStructuresQuery, Result<IReadOnlyCollection<ProductStructureResponse>>>
{
    public async Task<Result<IReadOnlyCollection<ProductStructureResponse>>> Handle(
        GetAllProductStructuresQuery request,
        CancellationToken cancellationToken)
    {
        var productStructures = await productStructureRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<ProductStructureResponse>)[.. productStructures
            .Select(x => new ProductStructureResponse(
                x.Id,
                x.MaterialId,
                x.SiteId,
                x.Usage.Name,
                x.AlternativeNumber,
                x.ValidFromDate,
                x.ValidToDate,
                x.OrderStatus.Name,
                x.Components.Count)
            )]);
    }
}