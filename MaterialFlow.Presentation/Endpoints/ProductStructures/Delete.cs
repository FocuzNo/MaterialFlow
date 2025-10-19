using MaterialFlow.Application.ProductStructures.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.ProductStructures;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.ProductStructures}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductStructureCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductStructures);
    }
}