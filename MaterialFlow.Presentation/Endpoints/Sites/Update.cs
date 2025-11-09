using MaterialFlow.Application.Sites.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.Sites;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.Sites, async (
            UpdateSiteCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.Sites)
        .RequireAuthorization();
    }
}