using MaterialFlow.Application.PurchaseRequests.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.PurchaseRequests;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(Urls.PurchaseRequests, async (
            UpdatePurchaseRequestCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PurchaseRequests)
        .RequireAuthorization();
    }
}