using MaterialFlow.Application.Sites.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.Sites;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.Sites, async (
            CreateSiteCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                id => Results.Created($"{Urls.Sites}/{id}", id),
                ApiResults.Problem
            );
        })
        .WithTags(Tags.Sites);
    }
}