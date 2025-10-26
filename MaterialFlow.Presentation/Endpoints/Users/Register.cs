using MaterialFlow.Application.Users.Commands.Register;

namespace MaterialFlow.Presentation.Endpoints.Users;

internal sealed class Register : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Urls.Users}/register", async (
            RegisterUserCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                id => Results.Created($"{Urls.Users}/{id}", id),
                ApiResults.Problem
            );
        })
        .WithTags(Tags.Users)
        .AllowAnonymous();
    }
}