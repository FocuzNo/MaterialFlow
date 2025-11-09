using MaterialFlow.Application.ComponentReservations.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.ComponentReservations;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.ComponentReservations, async (
            UpdateComponentReservationCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ComponentReservations)
        .RequireAuthorization();
    }
}
