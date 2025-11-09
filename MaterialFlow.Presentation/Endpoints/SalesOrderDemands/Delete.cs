using MaterialFlow.Application.SalesOrderDemands.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.SalesOrderDemands;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.SalesOrderDemands}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeleteSalesOrderDemandCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.SalesOrderDemands)
        .RequireAuthorization();
    }
}