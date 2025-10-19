namespace MaterialFlow.Application.Sites.Queries;

public sealed record SiteResponse(
    Guid Id,
    string PlantCode,
    string Name);