using MaterialFlow.Application.PurchaseRequests.Commands.Delete;

namespace MaterialFlow.Presentation.Endpoints.PurchaseRequests;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Urls.PurchaseRequests}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new DeletePurchaseRequestCommand(id));

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
        .WithTags(Tags.PurchaseRequests);
    }
}