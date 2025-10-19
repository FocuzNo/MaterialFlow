using MaterialFlow.Application.SalesOrderDemands.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.SalesOrderDemands;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.SalesOrderDemands, async (
            UpdateSalesOrderDemandCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.SalesOrderDemands);
    }
}