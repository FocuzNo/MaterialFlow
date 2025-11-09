using MaterialFlow.Application.PlannedProductionOrders.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.PlannedProductionOrders;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.PlannedProductionOrders, async (
            UpdatePlannedProductionOrderCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlannedProductionOrders)
        .RequireAuthorization();
    }
}