using MaterialFlow.Domain.ProductComponents;

namespace MaterialFlow.Application.ProductComponents.Commands.Update;

internal sealed class UpdateProductComponentCommandHandler(
    IProductComponentRepository productComponentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductComponentCommand, Result>
{
    public async Task<Result> Handle(
        UpdateProductComponentCommand request,
        CancellationToken cancellationToken)
    {
        var productComponent = await productComponentRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productComponent is null)
        {
            return Result.Failure(ProductComponentErrors.NotFound);
        }

        productComponent.Update(
            new UnitOfMeasure(request.UnitOfMeasure),
            new Quantity(
                request.QuantityPerAmount,
                new UnitOfMeasure(request.QuantityPerUnitOfMeasure)),
            request.ScrapPercentage);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}