using MaterialFlow.Application.StorageLocations.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.StorageLocations;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.StorageLocations}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetStorageLocationByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.StorageLocations)
        .RequireAuthorization();
    }
}