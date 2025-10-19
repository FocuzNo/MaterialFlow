using MaterialFlow.Application.PlanningAreas.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.PlanningAreas;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.PlanningAreas, async (
            UpdatePlanningAreaCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningAreas);
    }
}