using MaterialFlow.Application.PlanningRuns.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.PlanningRuns;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.PlanningRuns, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllPlanningRunsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRuns)
        .RequireAuthorization();
    }
}