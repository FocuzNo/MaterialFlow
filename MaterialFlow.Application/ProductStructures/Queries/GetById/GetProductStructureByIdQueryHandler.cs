using MaterialFlow.Domain.ProductStructures;

namespace MaterialFlow.Application.ProductStructures.Queries.GetById;

internal sealed class GetProductStructureByIdQueryHandler(IProductStructureRepository productStructureRepository)
    : IRequestHandler<GetProductStructureByIdQuery, Result<ProductStructureResponse>>
{
    public async Task<Result<ProductStructureResponse>> Handle(
        GetProductStructureByIdQuery request,
        CancellationToken cancellationToken)
    {
        var productStructure = await productStructureRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productStructure is null)
        {
            return Result.Failure<ProductStructureResponse>(ProductStructureErrors.NotFound);
        }

        var response = new ProductStructureResponse(
            productStructure.Id,
            productStructure.MaterialId,
            productStructure.SiteId,
            productStructure.Usage.Name,
            productStructure.AlternativeNumber,
            productStructure.ValidFromDate,
            productStructure.ValidToDate,
            productStructure.OrderStatus.Name,
            productStructure.Components.Count);

        return Result.Success(response);
    }
}