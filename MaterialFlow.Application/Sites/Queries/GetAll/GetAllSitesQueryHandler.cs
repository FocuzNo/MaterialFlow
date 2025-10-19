using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Application.Sites.Queries.GetAll;

internal sealed class GetAllSitesQueryHandler(ISiteRepository siteRepository)
    : IRequestHandler<GetAllSitesQuery, Result<IReadOnlyCollection<SiteResponse>>>
{
    public async Task<Result<IReadOnlyCollection<SiteResponse>>> Handle(
        GetAllSitesQuery request,
        CancellationToken cancellationToken)
    {
        var sites = await siteRepository.GetAllAsync(cancellationToken);

        return Result.Success((IReadOnlyCollection<SiteResponse>)[.. sites
            .Select(x => new SiteResponse(
                x.Id,
                x.PlantCode,
                x.Name)
            )]);
    }
}