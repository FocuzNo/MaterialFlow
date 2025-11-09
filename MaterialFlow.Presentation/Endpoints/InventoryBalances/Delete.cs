using MaterialFlow.Application.InventoryBalances.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.InventoryBalances;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(Urls.InventoryBalances, async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteInventoryBalanceCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.InventoryBalances)
        .RequireAuthorization();
    }
}