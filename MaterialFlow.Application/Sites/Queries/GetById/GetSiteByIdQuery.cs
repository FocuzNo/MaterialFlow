namespace MaterialFlow.Application.Sites.Queries.GetById;

public sealed record GetSiteByIdQuery(Guid Id) : IRequest<Result<SiteResponse>>;