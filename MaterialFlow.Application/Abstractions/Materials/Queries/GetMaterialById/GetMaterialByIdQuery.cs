namespace MaterialFlow.Application.Abstractions.Materials.Queries.GetMaterialById;

public sealed record GetMaterialByIdQuery(Guid Id) : IRequest<Result<MaterialResponse>>;