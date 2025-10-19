using MaterialFlow.Application.SalesOrderDemands.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.SalesOrderDemands;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.SalesOrderDemands, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllSalesOrderDemandsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.SalesOrderDemands);
    }
}