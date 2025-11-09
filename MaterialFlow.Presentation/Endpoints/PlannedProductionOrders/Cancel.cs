using MaterialFlow.Application.PlannedProductionOrders.Commands.Cancel;

namespace MaterialFlow.Presentation.Endpoints.PlannedProductionOrders;

internal sealed class Cancel : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Urls.PlannedProductionOrders}/{{id}}/cancel", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new CancelPlannedProductionOrderCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlannedProductionOrders)
        .RequireAuthorization();
    }
}