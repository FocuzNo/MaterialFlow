namespace MaterialFlow.Application.Materials.Queries.GetById;

public sealed record GetMaterialByIdQuery(Guid Id) : IRequest<Result<MaterialResponse>>;