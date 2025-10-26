namespace MaterialFlow.Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(User)}.{nameof(NotFound)}",
        "The user with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(User)}.{nameof(InvalidUpdate)}",
        "The user update is invalid");

    public static readonly Error AlreadyExists = new(
        $"{nameof(User)}.{nameof(AlreadyExists)}",
        "A user with this email already exists");

    public static readonly Error InvalidCredentials = new(
        $"{nameof(User)}.{nameof(InvalidCredentials)}",
        "The provided credentials are invalid");

    public static readonly Error UserInactive = new(
        $"{nameof(User)}.{nameof(UserInactive)}",
        "The user account is inactive");
}