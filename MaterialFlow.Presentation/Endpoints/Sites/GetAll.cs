using MaterialFlow.Application.Sites.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.Sites;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.Sites, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllSitesQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.Sites)
        .RequireAuthorization();
    }
}