using MaterialFlow.Application.ComponentReservations.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.ComponentReservations;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.ComponentReservations}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetComponentReservationByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ComponentReservations)
        .RequireAuthorization();
    }
}
