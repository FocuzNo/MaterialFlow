using MaterialFlow.Application.Users.Queries.GetLoggedInUser;

namespace MaterialFlow.Presentation.Endpoints.Users;

internal sealed class GetLoggedIn : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Urls.Users}/me", async (ISender sender) =>
        {
            var result = await sender.Send(new GetLoggedInUserQuery());

            return result.Match(
                Results.Ok,
                ApiResults.Problem);
        })
        .WithTags(Tags.Users)
        .RequireAuthorization();
    }
}