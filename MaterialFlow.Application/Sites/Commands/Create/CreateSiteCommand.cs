namespace MaterialFlow.Application.Sites.Commands.Create;

public sealed record CreateSiteCommand(
    string PlantCode,
    string Name) : IRequest<Guid>;