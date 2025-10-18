namespace MaterialFlow.Application.ProductStructures.Commands.RemoveComponent;

public sealed record RemoveProductComponentCommand(
    Guid ProductStructureId,
    Guid ComponentId) : IRequest<Result>;