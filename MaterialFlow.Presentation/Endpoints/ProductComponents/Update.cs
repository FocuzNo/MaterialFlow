using MaterialFlow.Application.ProductComponents.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.ProductComponents;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.ProductComponents, async (
            UpdateProductComponentCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductComponents)
        .RequireAuthorization();
    }
}