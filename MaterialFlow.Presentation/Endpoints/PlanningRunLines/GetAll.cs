using MaterialFlow.Application.PlanningRunLines.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.PlanningRunLines;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.PlanningRunLines, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllPlanningRunLinesQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRunLines);
    }
}