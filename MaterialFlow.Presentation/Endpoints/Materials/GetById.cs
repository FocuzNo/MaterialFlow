using MaterialFlow.Application.Materials.Queries.GetMaterialById;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.Material}/{{id:guid}}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetMaterialByIdQuery(id));

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
            .WithTags(Tags.Material);
    }
}