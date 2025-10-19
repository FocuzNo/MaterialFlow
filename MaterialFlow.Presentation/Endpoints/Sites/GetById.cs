using MaterialFlow.Application.Sites.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.Sites;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.Sites}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetSiteByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.Sites);
    }
}