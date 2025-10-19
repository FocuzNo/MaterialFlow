using MaterialFlow.Application.ProductionOrders.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.ProductionOrders;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.ProductionOrders}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetProductionOrderByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductionOrders);
    }
}