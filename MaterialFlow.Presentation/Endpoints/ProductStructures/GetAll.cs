using MaterialFlow.Application.ProductStructures.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.ProductStructures;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.ProductStructures, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllProductStructuresQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.ProductStructures);
    }
}