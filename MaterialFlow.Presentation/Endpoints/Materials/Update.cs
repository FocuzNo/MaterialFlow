using MaterialFlow.Application.Materials.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.Materials, async (
            UpdateMaterialCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.Materials)
        .RequireAuthorization();
    }
}
