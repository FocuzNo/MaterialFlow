using MaterialFlow.Application.ProductionOrders.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.ProductionOrders;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.ProductionOrders, async (
            CreateProductionOrderCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.ProductionOrders}/{id}", id);
        })
        .WithTags(Tags.ProductionOrders)
        .RequireAuthorization();
    }
}