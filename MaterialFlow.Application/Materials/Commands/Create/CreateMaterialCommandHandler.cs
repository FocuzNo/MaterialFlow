using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.ValueObjects;

namespace MaterialFlow.Application.Materials.Commands.Create;

public sealed class CreateMaterialCommandHandler(
    IMaterialRepository materialRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateMaterialCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateMaterialCommand request,
        CancellationToken cancellationToken)
    {
        var material = Material.Create(
            request.Id,
            new MaterialNumber(request.MaterialNumber),
            request.Description,
            request.BaseUnitOfMeasure,
            request.MRPType,
            request.LotSizePolicy,
            request.ProcurementType,
            request.PlannedDeliveryTimeInDays,
            request.SafetyStockQuantity);

        await materialRepository.AddAsync(
            material,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return material.Id;
    }
}