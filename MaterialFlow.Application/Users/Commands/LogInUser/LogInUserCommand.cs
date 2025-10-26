using MaterialFlow.Application.Abstractions.Messaging;

namespace MaterialFlow.Application.Users.Commands.LogInUser;

public sealed record LogInUserCommand(
    string Email,
    string Password) : ICommand<AccessTokenResponse>;