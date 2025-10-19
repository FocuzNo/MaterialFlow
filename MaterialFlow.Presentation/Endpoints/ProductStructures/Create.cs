using MaterialFlow.Application.ProductStructures.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.ProductStructures;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.ProductStructures, async (
            CreateProductStructureCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.ProductStructures}/{id}", id);
        })
        .WithTags(Tags.ProductStructures);
    }
}