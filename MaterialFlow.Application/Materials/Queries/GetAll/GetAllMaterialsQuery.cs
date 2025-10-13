namespace MaterialFlow.Application.Materials.Queries.GetAll;

public sealed record GetAllMaterialsQuery : IRequest<Result<IReadOnlyCollection<MaterialResponse>>>;