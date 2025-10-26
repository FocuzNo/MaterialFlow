using MaterialFlow.Domain.Users;

namespace MaterialFlow.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(User user, string password, CancellationToken cancellationToken = default);
}