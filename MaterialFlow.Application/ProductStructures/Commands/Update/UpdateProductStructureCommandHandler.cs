using MaterialFlow.Domain.ProductStructures;
using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Application.ProductStructures.Commands.Update;

internal sealed class UpdateProductStructureCommandHandler(
    IProductStructureRepository productStructureRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductStructureCommand, Result>
{
    public async Task<Result> Handle(
        UpdateProductStructureCommand request,
        CancellationToken cancellationToken)
    {
        var productStructure = await productStructureRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (productStructure is null)
        {
            return Result.Failure(ProductStructureErrors.NotFound);
        }

        productStructure.Update(
            request.MaterialId,
            request.SiteId,
            BillOfMaterialsUsage.FromValue(request.Usage),
            request.AlternativeNumber,
            request.ValidFromDate,
            request.ValidToDate,
            OrderStatus.FromValue(request.OrderStatus));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}