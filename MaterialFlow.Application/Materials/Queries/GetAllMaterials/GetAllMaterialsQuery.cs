using MaterialFlow.Application.Materials.Queries.GetMaterialById;

namespace MaterialFlow.Application.Materials.Queries.GetAllMaterials;

public sealed record GetAllMaterialsQuery : IRequest<Result<IReadOnlyList<MaterialResponse>>>;