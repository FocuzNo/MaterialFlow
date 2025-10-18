namespace MaterialFlow.Application.ProductStructures.Commands.Delete;

public sealed record DeleteProductStructureCommand(Guid Id) : IRequest<Result>;