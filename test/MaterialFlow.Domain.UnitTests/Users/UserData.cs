using MaterialFlow.Domain.Users;
using MaterialFlow.Domain.Users.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.Users;

internal static class UserData
{
    private const string DefaultPasswordHash = "hashedPassword123";

    public static User CreateUser(
        Guid? id = null,
        string? email = null,
        string? firstName = null,
        string? lastName = null,
        string? passwordHash = null) =>
        User.Create(
            id ?? Guid.NewGuid(),
            new Email(email ?? "test@test.com"),
            new FirstName(firstName ?? "John"),
            new LastName(lastName ?? "Doe"),
            passwordHash ?? DefaultPasswordHash);
}