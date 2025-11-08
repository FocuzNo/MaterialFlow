using MaterialFlow.Application.StorageLocations.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.StorageLocations;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.StorageLocations, async (
            CreateStorageLocationCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                id => Results.Created($"{Urls.StorageLocations}/{id}", id),
                ApiResults.Problem
            );
        })
        .WithTags(Tags.StorageLocations)
        .RequireAuthorization();
    }
}