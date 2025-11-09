using MaterialFlow.Application.ForecastPlanItems.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlanItems;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.ForecastPlanItems, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllForecastPlanItemsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlanItems)
        .RequireAuthorization();
    }
}