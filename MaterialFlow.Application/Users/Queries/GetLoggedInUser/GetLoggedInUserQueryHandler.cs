using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Application.Abstractions.Messaging;
using MaterialFlow.Domain.Users;

namespace MaterialFlow.Application.Users.Queries.GetLoggedInUser;

internal sealed class GetLoggedInUserQueryHandler(
    IUserRepository userRepository,
    IUserContext userContext)
    : IQueryHandler<GetLoggedInUserQuery, LoggedInUserResponse>
{
    public async Task<Result<LoggedInUserResponse>> Handle(
        GetLoggedInUserQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdentityIdAsync(
            userContext.IdentityId,
            cancellationToken);

        if (user is null)
        {
            return Result.Failure<LoggedInUserResponse>(UserErrors.NotFound);
        }

        if (!user.IsActive)
        {
            return Result.Failure<LoggedInUserResponse>(UserErrors.UserInactive);
        }

        var response = new LoggedInUserResponse(
            user.Id,
            user.Email.Value,
            user.FirstName.Value,
            user.LastName.Value,
            [.. user.Roles.Select(r => r.Name)]);

        return Result.Success(response);
    }
}