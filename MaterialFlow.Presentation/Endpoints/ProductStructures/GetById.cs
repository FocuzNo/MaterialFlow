using MaterialFlow.Application.ProductStructures.Queries.GetById;

namespace MaterialFlow.Presentation.Endpoints.ProductStructures;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.ProductStructures}/{{id}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetProductStructureByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductStructures);
    }
}