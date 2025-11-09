using MaterialFlow.Application.PlanningRunLines.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.PlanningRunLines;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.PlanningRunLines, async (
            UpdatePlanningRunLineCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRunLines)
        .RequireAuthorization();
    }
}