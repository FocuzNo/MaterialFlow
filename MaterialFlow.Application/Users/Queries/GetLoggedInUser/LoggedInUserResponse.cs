namespace MaterialFlow.Application.Users.Queries.GetLoggedInUser;

public sealed record LoggedInUserResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    IReadOnlyCollection<string> Roles);