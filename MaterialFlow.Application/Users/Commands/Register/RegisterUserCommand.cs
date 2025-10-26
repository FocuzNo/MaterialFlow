using MaterialFlow.Application.Abstractions.Messaging;

namespace MaterialFlow.Application.Users.Commands.Register;

public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Guid>;