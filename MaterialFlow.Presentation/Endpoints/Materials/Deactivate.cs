using MaterialFlow.Application.Materials.Commands.Deactivate;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class Deactivate : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(Urls.Materials, async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeactivateMaterialCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.Materials)
        .RequireAuthorization();
    }
}