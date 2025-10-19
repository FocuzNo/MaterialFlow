namespace MaterialFlow.Application.Sites.Queries.GetAll;

public sealed record GetAllSitesQuery : IRequest<Result<IReadOnlyCollection<SiteResponse>>>;