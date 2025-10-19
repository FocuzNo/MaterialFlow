using MaterialFlow.Domain.ProductComponents;

namespace MaterialFlow.Application.ProductComponents.Queries.GetAll;

internal sealed class GetAllProductComponentsQueryHandler(IProductComponentRepository productComponentRepository)
    : IRequestHandler<GetAllProductComponentsQuery, Result<IReadOnlyCollection<ProductComponentResponse>>>
{
    public async Task<Result<IReadOnlyCollection<ProductComponentResponse>>> Handle(
        GetAllProductComponentsQuery request,
        CancellationToken cancellationToken)
    {
        var productComponents = await productComponentRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<ProductComponentResponse>)[.. productComponents
            .Select(x => new ProductComponentResponse(
                x.Id,
                x.ProductStructureId,
                x.MaterialId,
                x.UnitOfMeasure.Value,
                x.QuantityPer.Amount,
                x.QuantityPer.UnitOfMeasure.Value,
                x.ScrapPercentage)
            )]);
    }
}