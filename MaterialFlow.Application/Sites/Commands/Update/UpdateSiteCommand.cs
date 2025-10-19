namespace MaterialFlow.Application.Sites.Commands.Update;

public sealed record UpdateSiteCommand(
    Guid Id,
    string PlantCode,
    string Name) : IRequest<Result>;