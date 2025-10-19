using MaterialFlow.Application.SalesOrderDemands.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.SalesOrderDemands;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.SalesOrderDemands}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetSalesOrderDemandByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.SalesOrderDemands);
    }
}