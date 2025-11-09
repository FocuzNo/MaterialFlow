using MaterialFlow.Application.PlanningRuns.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.PlanningRuns;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.PlanningRuns, async (
            UpdatePlanningRunCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRuns)
        .RequireAuthorization();
    }
}