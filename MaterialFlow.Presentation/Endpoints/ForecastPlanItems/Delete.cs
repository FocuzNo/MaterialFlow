using MaterialFlow.Application.ForecastPlanItems.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlanItems;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(Urls.ForecastPlanItems, async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteForecastPlanItemCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ForecastPlanItems);
    }
}