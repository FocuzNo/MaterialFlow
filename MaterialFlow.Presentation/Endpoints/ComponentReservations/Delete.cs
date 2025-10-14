using MaterialFlow.Application.ComponentReservations.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.ComponentReservations;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(Urls.ComponentReservations, async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteComponentReservationCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ComponentReservations);
    }
}
