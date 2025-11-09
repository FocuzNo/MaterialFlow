using MaterialFlow.Application.ProductStructures.Commands.AddComponent;

namespace MaterialFlow.Presentation.Endpoints.ProductStructures;

internal sealed class AddComponent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Urls.ProductStructures}/{{productStructureId}}/components", async (
            Guid productStructureId,
            AddProductComponentCommand command,
            ISender sender) =>
        {
            var commandWithId = command with { ProductStructureId = productStructureId };
            var result = await sender.Send(commandWithId);

            return result.Match(
                componentId => Results.Created($"{Urls.ProductStructures}/{productStructureId}/components/{componentId}", componentId),
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductStructures)
        .RequireAuthorization();
    }
}