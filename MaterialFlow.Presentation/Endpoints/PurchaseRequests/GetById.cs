using MaterialFlow.Application.PurchaseRequests.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.PurchaseRequests;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.PurchaseRequests}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetPurchaseRequestByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PurchaseRequests);
    }
}