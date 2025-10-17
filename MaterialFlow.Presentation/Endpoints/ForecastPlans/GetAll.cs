using MaterialFlow.Application.ForecastPlans.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlans;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.ForecastPlans, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllForecastPlansQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlans);
    }
}