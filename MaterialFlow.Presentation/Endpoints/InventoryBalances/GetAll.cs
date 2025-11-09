using MaterialFlow.Application.InventoryBalances.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.InventoryBalances;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.InventoryBalances, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllInventoryBalancesQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.InventoryBalances)
        .RequireAuthorization();
    }
}