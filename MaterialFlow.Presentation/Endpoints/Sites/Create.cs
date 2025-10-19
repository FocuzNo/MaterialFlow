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
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.Sites}/{id}", id);
        })
        .WithTags(Tags.Sites);
    }
}