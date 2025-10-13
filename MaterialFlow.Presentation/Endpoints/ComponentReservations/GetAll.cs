using MaterialFlow.Application.ComponentReservations.Queries.GetAll;
using MaterialFlow.Application.ComponentReservations.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.ComponentReservations;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.ComponentReservations, async (
            ISender sender) =>
        {
            Result<IReadOnlyCollection<ComponentReservationResponse>> result = await sender.Send(
                new GetAllComponentReservationsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ComponentReservations);
    }
}
