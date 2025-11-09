using MaterialFlow.Application.StorageLocations.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.StorageLocations;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.StorageLocations, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllStorageLocationsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.StorageLocations)
        .RequireAuthorization();
    }
}