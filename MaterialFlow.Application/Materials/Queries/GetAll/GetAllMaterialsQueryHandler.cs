using MaterialFlow.Domain.Materials;

namespace MaterialFlow.Application.Materials.Queries.GetAll;

internal sealed class GetAllMaterialsQueryHandler(IMaterialRepository materialRepository)
    : IRequestHandler<GetAllMaterialsQuery, Result<IReadOnlyCollection<MaterialResponse>>>
{
    public async Task<Result<IReadOnlyCollection<MaterialResponse>>> Handle(
        GetAllMaterialsQuery request,
        CancellationToken cancellationToken)
    {
        var materials = await materialRepository.GetAllAsync(cancellationToken);

        IReadOnlyCollection<MaterialResponse> response = [.. materials
            .Select(x => new MaterialResponse(
                x.Id,
                x.MaterialNumber.Value,
                x.Description,
                x.UnitOfMeasure.Value,
                x.MaterialRequirementsPlanningType.Name,
                x.LotSizePolicy.Name,
                x.ProcurementType.Name,
                x.PlannedDeliveryTimeInDays,
                x.SafetyStockQuantity.Amount,
                x.IsActive)
            )];

        return Result.Success(response);
    }
}