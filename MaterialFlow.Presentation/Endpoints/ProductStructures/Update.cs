using MaterialFlow.Application.ProductStructures.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.ProductStructures;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.ProductStructures, async (
            UpdateProductStructureCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductStructures);
    }
}