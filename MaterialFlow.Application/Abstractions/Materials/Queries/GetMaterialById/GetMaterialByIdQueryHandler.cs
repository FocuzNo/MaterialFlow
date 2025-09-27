using MaterialFlow.Domain.Materials;

namespace MaterialFlow.Application.Abstractions.Materials.Queries.GetMaterialById;

public sealed class GetMaterialByIdQueryHandler(IMaterialRepository materialRepository)
    : IRequestHandler<GetMaterialByIdQuery, Result<MaterialResponse>>
{
    public async Task<Result<MaterialResponse>> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var material = await materialRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (material is null)
        {
            return Result.Failure<MaterialResponse>(MaterialErrors.NotFound);
        }

        var response = new MaterialResponse(
            material.Id,
            material.MaterialNumber.Value,
            material.Description,
            material.BaseUnitOfMeasure.Value,
            material.MaterialRequirementsPlanningType.Name,
            material.LotSizePolicy.Name,
            material.ProcurementType.Name,
            material.PlannedDeliveryTimeInDays,
            material.SafetyStockQuantity.Amount,
            material.IsActive
        );

        return Result.Success(response);
    }
}