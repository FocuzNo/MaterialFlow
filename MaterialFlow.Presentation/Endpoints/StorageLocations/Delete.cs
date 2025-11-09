using MaterialFlow.Application.StorageLocations.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.StorageLocations;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.StorageLocations}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteStorageLocationCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.StorageLocations)
        .RequireAuthorization();
    }
}