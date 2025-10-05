using MaterialFlow.Application.Materials.Commands.Create;

namespace MaterialFlow.Presentation.Endpoints.Materials;

internal sealed class CreateMaterialEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/materials", async (
            CreateMaterialCommand request,
            ISender sender) =>
        {
            var id = await sender.Send(request);

            return Result.Create($"/materials/{id}");
        })
            .WithTags("Materials");
    }
}