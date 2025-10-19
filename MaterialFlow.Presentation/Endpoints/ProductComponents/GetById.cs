using MaterialFlow.Application.ProductComponents.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.ProductComponents;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.ProductComponents}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetProductComponentByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductComponents);
    }
}