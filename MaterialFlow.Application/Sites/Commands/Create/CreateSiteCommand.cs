namespace MaterialFlow.Application.Sites.Commands.Create;

public record CreateSiteCommand(
    string PlantCode,
    string Name) : IRequest<Result<Guid>>;