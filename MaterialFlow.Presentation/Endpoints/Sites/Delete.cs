using MaterialFlow.Application.Sites.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.Sites;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.Sites}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteSiteCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.Sites)
        .RequireAuthorization();
    }
}