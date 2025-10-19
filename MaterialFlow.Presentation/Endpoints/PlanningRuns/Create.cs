using MaterialFlow.Application.PlanningRuns.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.PlanningRuns;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.PlanningRuns, async (
            CreatePlanningRunCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.PlanningRuns}/{id}", id);
        })
        .WithTags(Tags.PlanningRuns);
    }
}