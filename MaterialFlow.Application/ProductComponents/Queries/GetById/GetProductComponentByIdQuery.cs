namespace MaterialFlow.Application.ProductComponents.Queries.GetById;

public sealed record GetProductComponentByIdQuery(Guid Id) : IRequest<Result<ProductComponentResponse>>;