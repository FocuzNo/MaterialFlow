using MaterialFlow.Application.ForecastPlanItems.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlanItems;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.ForecastPlanItems}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetForecastPlanItemByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlanItems);
    }
}