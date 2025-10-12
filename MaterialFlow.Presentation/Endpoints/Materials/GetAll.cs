using MaterialFlow.Application.Materials.Queries.GetAllMaterials;
using MaterialFlow.Application.Materials.Queries.GetMaterialById;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Urls.Material, async (
            ISender sender) =>
        {
            Result<IReadOnlyCollection<MaterialResponse>> result =
                await sender.Send(new GetAllMaterialsQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.Material);
    }
}