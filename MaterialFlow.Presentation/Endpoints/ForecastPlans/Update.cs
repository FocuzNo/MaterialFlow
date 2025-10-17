using MaterialFlow.Application.ForecastPlans.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlans;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.ForecastPlans, async (
            UpdateForecastPlanCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlans);
    }
}