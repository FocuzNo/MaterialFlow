using MaterialFlow.Application.ForecastPlans.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlans;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.ForecastPlans}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetForecastPlanByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlans)
        .RequireAuthorization();
    }
}