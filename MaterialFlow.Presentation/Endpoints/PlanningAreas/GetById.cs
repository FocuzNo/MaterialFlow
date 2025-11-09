using MaterialFlow.Application.PlanningAreas.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.PlanningAreas;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.PlanningAreas}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetPlanningAreaByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlanningAreas)
        .RequireAuthorization();
    }
}