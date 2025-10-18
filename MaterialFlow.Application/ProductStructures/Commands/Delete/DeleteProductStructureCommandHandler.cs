using MaterialFlow.Domain.ProductStructures;

namespace MaterialFlow.Application.ProductStructures.Commands.Delete;

internal sealed class DeleteProductStructureCommandHandler(
    IProductStructureRepository productStructureRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductStructureCommand, Result>
{
    public async Task<Result> Handle(
        DeleteProductStructureCommand request,
        CancellationToken cancellationToken)
    {
        var productStructure = await productStructureRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productStructure is null)
        {
            return Result.Failure(ProductStructureErrors.NotFound);
        }

        productStructureRepository.Delete(productStructure);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}