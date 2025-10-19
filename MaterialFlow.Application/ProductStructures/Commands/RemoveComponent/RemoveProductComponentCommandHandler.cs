using MaterialFlow.Domain.ProductStructures;

namespace MaterialFlow.Application.ProductStructures.Commands.RemoveComponent;

internal sealed class RemoveProductComponentCommandHandler(
    IProductStructureRepository productStructureRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveProductComponentCommand, Result>
{
    public async Task<Result> Handle(
        RemoveProductComponentCommand request,
        CancellationToken cancellationToken)
    {
        var productStructure = await productStructureRepository.GetByIdAsync(
            request.ProductStructureId,
            cancellationToken);

        if (productStructure is null)
        {
            return Result.Failure(ProductStructureErrors.NotFound);
        }

        productStructure.RemoveComponent(request.ComponentId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}