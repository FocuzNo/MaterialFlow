using MaterialFlow.Domain.ProductStructures;

namespace MaterialFlow.Application.ProductStructures.Commands.AddComponent;

internal sealed class AddProductComponentCommandHandler(
    IProductStructureRepository productStructureRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<AddProductComponentCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        AddProductComponentCommand request,
        CancellationToken cancellationToken)
    {
        var productStructure = await productStructureRepository.GetByIdAsync(
            request.ProductStructureId,
            cancellationToken);

        if (productStructure is null)
        {
            return Result.Failure<Guid>(ProductStructureErrors.NotFound);
        }

        var component = productStructure.AddComponent(
            request.ComponentMaterialId,
            new UnitOfMeasure(request.UnitOfMeasure),
            new Quantity(
                request.QuantityPerAmount,
                new UnitOfMeasure(request.QuantityPerUnitOfMeasure)),
            request.ScrapPercentage);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(component.Id);
    }
}