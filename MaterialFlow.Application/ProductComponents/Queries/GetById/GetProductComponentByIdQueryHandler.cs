using MaterialFlow.Domain.ProductComponents;

namespace MaterialFlow.Application.ProductComponents.Queries.GetById;

internal sealed class GetProductComponentByIdQueryHandler(IProductComponentRepository productComponentRepository)
    : IRequestHandler<GetProductComponentByIdQuery, Result<ProductComponentResponse>>
{
    public async Task<Result<ProductComponentResponse>> Handle(
        GetProductComponentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var productComponent = await productComponentRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productComponent is null)
        {
            return Result.Failure<ProductComponentResponse>(ProductComponentErrors.NotFound);
        }

        var response = new ProductComponentResponse(
            productComponent.Id,
            productComponent.ProductStructureId,
            productComponent.MaterialId,
            productComponent.UnitOfMeasure.Value,
            productComponent.QuantityPer.Amount,
            productComponent.QuantityPer.UnitOfMeasure.Value,
            productComponent.ScrapPercentage);

        return Result.Success(response);
    }
}