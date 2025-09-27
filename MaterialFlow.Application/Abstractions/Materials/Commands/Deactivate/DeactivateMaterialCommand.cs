namespace MaterialFlow.Application.Abstractions.Materials.Commands.Deactivate;

public sealed record DeactivateMaterialCommand(Guid Id) : IRequest<Result>;