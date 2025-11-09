using MaterialFlow.Application.PlannedProductionOrders.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.PlannedProductionOrders;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.PlannedProductionOrders, async (
            CreatePlannedProductionOrderCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.PlannedProductionOrders}/{id}", id);
        })
        .WithTags(Tags.PlannedProductionOrders)
        .RequireAuthorization();
    }
}