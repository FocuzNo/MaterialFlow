namespace MaterialFlow.Application.ProductComponents.Commands.Delete;

public sealed record DeleteProductComponentCommand(Guid Id) : IRequest<Result>;