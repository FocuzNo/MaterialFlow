using MaterialFlow.Application.ComponentReservations.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.ComponentReservations;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.ComponentReservations, async (
            CreateComponentReservationCommand command,
            ISender sender) =>
        {
            Result<Guid> result = await sender.Send(command);

            return result.Match(
                id => Results.Created($"{Urls.ComponentReservations}/{id}", id),
                ApiResults.Problem);
        })
        .WithTags(Tags.ComponentReservations)
        .RequireAuthorization();
    }
}
