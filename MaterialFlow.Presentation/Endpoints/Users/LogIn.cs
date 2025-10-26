using MaterialFlow.Application.Users.Commands.LogInUser;

namespace MaterialFlow.Presentation.Endpoints.Users;

internal sealed class LogIn : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Urls.Users}/login", async (
            LogInUserCommand command,
            ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(
                token => Results.Ok(token),
                ApiResults.Problem
            );
        })
        .WithTags(Tags.Users)
        .AllowAnonymous();
    }
}