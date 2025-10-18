namespace MaterialFlow.Application.ProductComponents.Queries.GetAll;

public sealed record GetAllProductComponentsQuery : IRequest<Result<IReadOnlyCollection<ProductComponentResponse>>>;