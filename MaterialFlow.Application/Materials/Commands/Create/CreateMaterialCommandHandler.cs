using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
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
            Guid.NewGuid(),
            new MaterialNumber(request.MaterialNumber),
            request.Description,
            new UnitOfMeasure(request.UnitOfMeasure),
            MaterialRequirementsPlanningType.FromValue(request.MaterialRequirementsPlanningType),
            LotSizePolicy.FromValue(request.LotSizePolicy),
            ProcurementType.FromValue(request.ProcurementType),
            request.PlannedDeliveryTimeInDays,
            new Quantity(
                request.SafetyStockAmount,
                new UnitOfMeasure(request.SafetyStockUnitOfMeasure)));

        await materialRepository.AddAsync(
            material,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return material.Id;
    }
}
