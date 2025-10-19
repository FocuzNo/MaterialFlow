using MaterialFlow.Domain.ProductComponents;

namespace MaterialFlow.Application.ProductComponents.Commands.Create;

internal sealed class CreateProductComponentCommandHandler(
    IProductComponentRepository productComponentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateProductComponentCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateProductComponentCommand request,
        CancellationToken cancellationToken)
    {
        var productComponent = ProductComponent.Create(
            Guid.NewGuid(),
            request.ProductStructureId,
            request.MaterialId,
            new UnitOfMeasure(request.UnitOfMeasure),
            new Quantity(
                request.QuantityPerAmount,
                new UnitOfMeasure(request.QuantityPerUnitOfMeasure)),
            request.ScrapPercentage);

        await productComponentRepository.AddAsync(
            productComponent,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return productComponent.Id;
    }
}