using MaterialFlow.Application.ProductComponents.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.ProductComponents;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.ProductComponents, async (
            CreateProductComponentCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.ProductComponents}/{id}", id);
        })
        .WithTags(Tags.ProductComponents)
        .RequireAuthorization();
    }
}