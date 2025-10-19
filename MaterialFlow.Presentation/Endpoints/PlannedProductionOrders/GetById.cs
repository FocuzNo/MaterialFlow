using MaterialFlow.Application.PlannedProductionOrders.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.PlannedProductionOrders;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.PlannedProductionOrders}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetPlannedProductionOrderByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PlannedProductionOrders);
    }
}