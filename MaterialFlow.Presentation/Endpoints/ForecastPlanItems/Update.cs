using MaterialFlow.Application.ForecastPlanItems.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlanItems;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.ForecastPlanItems, async (
            UpdateForecastPlanItemCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlanItems)
        .RequireAuthorization();
    }
}