using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Application.Sites.Queries.GetById;

internal sealed class GetSiteByIdQueryHandler(ISiteRepository siteRepository)
    : IRequestHandler<GetSiteByIdQuery, Result<SiteResponse>>
{
    public async Task<Result<SiteResponse>> Handle(
        GetSiteByIdQuery request,
        CancellationToken cancellationToken)
    {
        var site = await siteRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (site is null)
        {
            return Result.Failure<SiteResponse>(SiteErrors.NotFound);
        }

        var response = new SiteResponse(
            site.Id,
            site.PlantCode,
            site.Name);

        return Result.Success(response);
    }
}