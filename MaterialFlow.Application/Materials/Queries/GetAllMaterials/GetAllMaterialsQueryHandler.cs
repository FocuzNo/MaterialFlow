using MaterialFlow.Application.Materials.Queries.GetMaterialById;
using MaterialFlow.Domain.Materials;

namespace MaterialFlow.Application.Materials.Queries.GetAllMaterials;

public sealed class GetAllMaterialsQueryHandler(IMaterialRepository materialRepository)
    : IRequestHandler<GetAllMaterialsQuery, Result<IReadOnlyList<MaterialResponse>>>
{
    public async Task<Result<IReadOnlyList<MaterialResponse>>> Handle(
        GetAllMaterialsQuery request,
        CancellationToken cancellationToken)
    {
        var materials = await materialRepository.GetAllAsync(cancellationToken);

        var response = materials.Select(x => new MaterialResponse(
            x.Id,
            x.MaterialNumber.Value,
            x.Description,
            x.BaseUnitOfMeasure.Value,
            x.MaterialRequirementsPlanningType.Name,
            x.LotSizePolicy.Name,
            x.ProcurementType.Name,
            x.PlannedDeliveryTimeInDays,
            x.SafetyStockQuantity.Amount,
            x.IsActive
        )).ToList();

        return Result.Success<IReadOnlyList<MaterialResponse>>(response);
    }
}