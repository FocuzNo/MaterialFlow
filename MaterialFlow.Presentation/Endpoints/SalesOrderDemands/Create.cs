using MaterialFlow.Application.SalesOrderDemands.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.SalesOrderDemands;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.SalesOrderDemands, async (
            CreateSalesOrderDemandCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.SalesOrderDemands}/{id}", id);
        })
        .WithTags(Tags.SalesOrderDemands)
        .RequireAuthorization();
    }
}