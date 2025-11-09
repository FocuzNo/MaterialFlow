using MaterialFlow.Application.ProductStructures.Commands.RemoveComponent;

namespace MaterialFlow.Presentation.Endpoints.ProductStructures;

internal sealed class RemoveComponent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.ProductStructures}/{{productStructureId}}/components/{{componentId}}", async (
            Guid productStructureId,
            Guid componentId,
            ISender sender) =>
        {
            var result = await sender.Send(new RemoveProductComponentCommand(
                productStructureId,
                componentId));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductStructures)
        .RequireAuthorization();
    }
}