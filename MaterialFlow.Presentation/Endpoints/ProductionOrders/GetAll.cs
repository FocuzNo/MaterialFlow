using MaterialFlow.Application.ProductionOrders.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.ProductionOrders;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.ProductionOrders, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllProductionOrdersQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductionOrders);
    }
}