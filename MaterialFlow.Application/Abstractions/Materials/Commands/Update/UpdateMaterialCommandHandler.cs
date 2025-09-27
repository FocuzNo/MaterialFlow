using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.ValueObjects;

namespace MaterialFlow.Application.Abstractions.Materials.Commands.Update;

public sealed class UpdateMaterialCommandHandler(
    IMaterialRepository materialRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<UpdateMaterialCommand, Result>
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
            request.BaseUnitOfMeasure,
            request.MRPType,
            request.LotSizePolicy,
            request.ProcurementType,
            request.PlannedDeliveryTimeInDays,
            request.SafetyStockQuantity);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}