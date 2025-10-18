namespace MaterialFlow.Application.ProductStructures.Queries.GetById;

public sealed record GetProductStructureByIdQuery(Guid Id) : IRequest<Result<ProductStructureResponse>>;