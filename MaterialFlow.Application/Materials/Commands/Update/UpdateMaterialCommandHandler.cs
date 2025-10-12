using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Materials.ValueObjects;

namespace MaterialFlow.Application.Materials.Commands.Update;

public sealed class UpdateMaterialCommandHandler(
    IMaterialRepository materialRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateMaterialCommand, Result>
{
    public async Task<Result> Handle(
        UpdateMaterialCommand request,
        CancellationToken cancellationToken)
    {
        var material = await materialRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (material is null)
        {
            return Result.Failure(MaterialErrors.NotFound);
        }

        material.Update(
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

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}