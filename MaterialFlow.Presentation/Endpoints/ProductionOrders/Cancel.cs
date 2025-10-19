using MaterialFlow.Application.ProductionOrders.Commands.Cancel;

namespace MaterialFlow.Presentation.Endpoints.ProductionOrders;

internal sealed class Cancel : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Urls.ProductionOrders}/{{id}}/cancel", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new CancelProductionOrderCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductionOrders);
    }
}