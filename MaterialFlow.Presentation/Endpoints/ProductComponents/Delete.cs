using MaterialFlow.Application.ProductComponents.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.ProductComponents;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.ProductComponents}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductComponentCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductComponents);
    }
}