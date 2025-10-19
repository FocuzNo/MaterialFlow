using MaterialFlow.Application.PlanningRuns.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.PlanningRuns;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.PlanningRuns}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetPlanningRunByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningRuns);
    }
}