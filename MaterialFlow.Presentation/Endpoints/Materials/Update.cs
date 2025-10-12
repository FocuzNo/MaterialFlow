using MaterialFlow.Application.Materials.Commands.Update;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut($"{Urls.Material}/{{id:guid}}", async (
            Guid id,
            UpdateMaterialCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command with { Id = id });

            return result.Match(
                Results.NoContent,
                ApiResults.Problem);
        })
            .WithTags(Tags.Material);
    }
}