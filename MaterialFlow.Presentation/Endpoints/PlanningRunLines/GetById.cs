using MaterialFlow.Application.PlanningRunLines.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.PlanningRunLines;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.PlanningRunLines}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetPlanningRunLineByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRunLines);
    }
}