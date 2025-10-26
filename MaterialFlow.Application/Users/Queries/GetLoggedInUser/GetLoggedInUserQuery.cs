using MaterialFlow.Application.Abstractions.Messaging;

namespace MaterialFlow.Application.Users.Queries.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<LoggedInUserResponse>;