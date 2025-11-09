using MaterialFlow.Application.PlanningAreas.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.PlanningAreas;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.PlanningAreas, async (
            CreatePlanningAreaCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.PlanningAreas}/{id}", id);
        })
        .WithTags(Tags.PlanningAreas)
        .RequireAuthorization();
    }
}