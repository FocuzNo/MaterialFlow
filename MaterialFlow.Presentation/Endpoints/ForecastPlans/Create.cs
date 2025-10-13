using MaterialFlow.Application.ForecastPlans.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.ForecastPlans;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.ForecastPlans, async (
            CreateForecastPlanCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.ForecastPlans}/{id}", id);
        })
        .WithTags(Tags.ForecastPlans);
    }
}