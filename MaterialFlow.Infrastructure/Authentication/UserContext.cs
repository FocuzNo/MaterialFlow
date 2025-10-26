using MaterialFlow.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class UserContext(IHttpContextAccessor accessor) : IUserContext
{
    public Guid UserId => accessor.HttpContext?.User.GetUserId()
        ?? throw new ApplicationException("User context is unavailable");

    public string IdentityId => accessor.HttpContext?.User.GetIdentityId()
        ?? throw new ApplicationException("User context is unavailable");
}