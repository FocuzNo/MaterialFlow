using MaterialFlow.Application.PlanningAreas.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.PlanningAreas;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.PlanningAreas}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeletePlanningAreaCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningAreas)
        .RequireAuthorization();
    }
}