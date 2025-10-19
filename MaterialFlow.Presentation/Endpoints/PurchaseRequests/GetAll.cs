using MaterialFlow.Application.PurchaseRequests.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.PurchaseRequests;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.PurchaseRequests, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllPurchaseRequestsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.PurchaseRequests);
    }
}