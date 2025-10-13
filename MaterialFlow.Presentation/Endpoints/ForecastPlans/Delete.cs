using MaterialFlow.Application.ForecastPlans.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlans;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(Urls.ForecastPlans, async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteForecastPlanCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlans);
    }
}