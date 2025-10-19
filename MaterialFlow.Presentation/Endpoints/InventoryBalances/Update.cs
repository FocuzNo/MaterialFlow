using MaterialFlow.Application.InventoryBalances.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.InventoryBalances;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.InventoryBalances, async (
            UpdateInventoryBalanceCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.InventoryBalances);
    }
}