using MaterialFlow.Application.Materials.Queries;
using MaterialFlow.Application.Materials.Queries.GetAll;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.Materials, async (ISender sender) =>
        {
            Result<IReadOnlyCollection<MaterialResponse>> result = await sender.Send(
                new GetAllMaterialsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.Materials);
    }
}