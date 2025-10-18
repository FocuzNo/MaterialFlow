namespace MaterialFlow.Application.ProductStructures.Queries.GetAll;

public sealed record GetAllProductStructuresQuery : IRequest<Result<IReadOnlyCollection<ProductStructureResponse>>>;