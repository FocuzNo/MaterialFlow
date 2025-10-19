namespace MaterialFlow.Application.Sites.Commands.Delete;

public sealed record DeleteSiteCommand(Guid Id) : IRequest<Result>;