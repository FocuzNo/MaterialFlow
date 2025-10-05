namespace MaterialFlow.Application.Materials.Commands.Deactivate;

public sealed record DeactivateMaterialCommand(Guid Id) : IRequest<Result>;