using MaterialFlow.Application.InventoryBalances.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.InventoryBalances;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.InventoryBalances}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetInventoryBalanceByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.InventoryBalances);
    }
}