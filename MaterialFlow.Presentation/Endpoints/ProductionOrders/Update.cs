using MaterialFlow.Application.ProductionOrders.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.ProductionOrders;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.ProductionOrders, async (
            UpdateProductionOrderCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductionOrders);
    }
}