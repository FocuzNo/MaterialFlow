using MaterialFlow.Domain.ProductComponents;

namespace MaterialFlow.Application.ProductComponents.Commands.Delete;

internal sealed class DeleteProductComponentCommandHandler(
    IProductComponentRepository productComponentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductComponentCommand, Result>
{
    public async Task<Result> Handle(
        DeleteProductComponentCommand request,
        CancellationToken cancellationToken)
    {
        var productComponent = await productComponentRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productComponent is null)
        {
            return Result.Failure(ProductComponentErrors.NotFound);
        }

        productComponentRepository.Delete(productComponent);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}