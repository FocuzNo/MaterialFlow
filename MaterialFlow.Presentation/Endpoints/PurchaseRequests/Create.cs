using MaterialFlow.Application.PurchaseRequests.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.PurchaseRequests;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Urls.PurchaseRequests, async (
            CreatePurchaseRequestCommand command,
            ISender sender) =>
        {
            Guid id = await sender.Send(command);

            return Results.Created($"{Urls.PurchaseRequests}/{id}", id);
        })
        .WithTags(Tags.PurchaseRequests);
    }
}