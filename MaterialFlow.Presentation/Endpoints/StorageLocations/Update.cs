using MaterialFlow.Application.StorageLocations.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.StorageLocations;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.StorageLocations, async (
            UpdateStorageLocationCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.StorageLocations);
    }
}