using MaterialFlow.Application.PlannedProductionOrders.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.PlannedProductionOrders;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.PlannedProductionOrders, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllPlannedProductionOrdersQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlannedProductionOrders)
        .RequireAuthorization();
    }
}