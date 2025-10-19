using MaterialFlow.Application.PlanningRunLines.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.PlanningRunLines;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.PlanningRunLines}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeletePlanningRunLineCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRunLines);
    }
}