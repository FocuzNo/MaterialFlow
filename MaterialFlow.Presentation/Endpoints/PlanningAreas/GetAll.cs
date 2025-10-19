using MaterialFlow.Application.PlanningAreas.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.PlanningAreas;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.PlanningAreas, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllPlanningAreasQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningAreas);
    }
}