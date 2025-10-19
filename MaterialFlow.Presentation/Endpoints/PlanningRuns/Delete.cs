using MaterialFlow.Application.PlanningRuns.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.PlanningRuns;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.PlanningRuns}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeletePlanningRunCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRuns);
    }
}