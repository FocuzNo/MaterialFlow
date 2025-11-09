using MaterialFlow.Application.ProductComponents.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.ProductComponents;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.ProductComponents, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllProductComponentsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductComponents)
        .RequireAuthorization();
    }
}