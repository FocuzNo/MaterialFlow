using MaterialFlow.Domain.ProductStructures;
using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Application.ProductStructures.Commands.Create;

internal sealed class CreateProductStructureCommandHandler(
    IProductStructureRepository productStructureRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateProductStructureCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateProductStructureCommand request,
        CancellationToken cancellationToken)
    {
        var productStructure = ProductStructure.Create(
            Guid.NewGuid(),
            request.MaterialId,
            request.SiteId,
            BillOfMaterialsUsage.FromValue(request.Usage),
            request.AlternativeNumber,
            request.ValidFromDate,
            request.ValidToDate,
            OrderStatus.FromValue(request.OrderStatus));

        await productStructureRepository.AddAsync(
            productStructure,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return productStructure.Id;
    }
}