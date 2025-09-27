using MaterialFlow.Application.Abstractions.Materials.Queries.GetMaterialById;

namespace MaterialFlow.Application.Abstractions.Materials.Queries.GetAllMaterials;

public sealed record GetAllMaterialsQuery : IRequest<Result<IReadOnlyList<MaterialResponse>>>;