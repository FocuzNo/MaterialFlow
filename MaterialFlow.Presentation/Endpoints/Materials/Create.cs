using MaterialFlow.Application.Materials.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.Materials, async (
            CreateMaterialCommand command,
            ISender sender) =>
        {
            Result<Guid> result = await sender.Send(command);

            return result.Match(
                id => Results.Created($"{Urls.Materials}/{id}", id),
                ApiResults.Problem);
        })
        .WithTags(Tags.Materials);
    }
}
