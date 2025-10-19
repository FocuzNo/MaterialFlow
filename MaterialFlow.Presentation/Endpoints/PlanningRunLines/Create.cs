using MaterialFlow.Application.PlanningRunLines.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.PlanningRunLines;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.PlanningRunLines, async (
            CreatePlanningRunLineCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.PlanningRunLines}/{id}", id);
        })
        .WithTags(Tags.PlanningRunLines);
    }
}