using MaterialFlow.Application.InventoryBalances.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.InventoryBalances;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.InventoryBalances, async (
            CreateInventoryBalanceCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.InventoryBalances}/{id}", id);
        })
        .WithTags(Tags.InventoryBalances)
        .RequireAuthorization();
    }
}