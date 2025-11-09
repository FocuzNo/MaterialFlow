using MaterialFlow.Application.ForecastPlanItems.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlanItems;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.ForecastPlanItems, async (
            CreateForecastPlanItemCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.ForecastPlanItems}/{id}", id);
        })
        .WithTags(Tags.ForecastPlanItems)
        .RequireAuthorization();
    }
}