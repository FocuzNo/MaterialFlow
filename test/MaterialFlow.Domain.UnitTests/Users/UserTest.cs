using MaterialFlow.Domain.Users;
using MaterialFlow.Domain.Users.Events;
using MaterialFlow.Domain.Users.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.Users;

public sealed class UserTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeUser_WithCorrectProperties()
    {
        var userId = Guid.NewGuid();
        var email = new Email("test@test.com");
        var firstName = new FirstName("John");
        var lastName = new LastName("Doe");
        const string passwordHash = "hash123";

        var user = User.Create(
            userId,
            email,
            firstName,
            lastName,
            passwordHash);

        user.Id.Should().Be(userId);
        user.Email.Should().Be(email);
        user.FirstName.Should().Be(firstName);
        user.LastName.Should().Be(lastName);
        user.PasswordHash.Should().Be(passwordHash);
        user.IsActive.Should().BeTrue();
        user.IdentityId.Should().BeEmpty();
        user.Roles.Should().BeEmpty();
    }

    [Fact]
    public void Create_ShouldRaise_UserCreatedDomainEvent()
    {
        var userId = Guid.NewGuid();

        var user = UserData.CreateUser(id: userId);

        var domainEvent = AssertDomainEventWasPublished<UserCreatedDomainEvent>(user);

        domainEvent.UserId.Should().Be(userId);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var user = UserData.CreateUser();
        var newEmail = new Email("new@test.com");
        var newFirstName = new FirstName("Jane");
        var newLastName = new LastName("Smith");

        user.Update(
            newEmail,
            newFirstName,
            newLastName);

        user.Email.Should().Be(newEmail);
        user.FirstName.Should().Be(newFirstName);
        user.LastName.Should().Be(newLastName);
    }

    [Fact]
    public void Update_ShouldRaise_UserUpdatedDomainEvent()
    {
        var user = UserData.CreateUser();

        user.ClearDomainEvents();

        user.Update(
            new Email("new@test.com"),
            new FirstName("Jane"),
            new LastName("Smith"));

        var domainEvent = AssertDomainEventWasPublished<UserUpdatedDomainEvent>(user);

        domainEvent.UserId.Should().Be(user.Id);
    }

    [Fact]
    public void Update_ShouldNotModify_OtherProperties()
    {
        var user = UserData.CreateUser();

        var originalPasswordHash = user.PasswordHash;

        user.Update(
            new Email("new@test.com"),
            new FirstName("Jane"),
            new LastName("Smith"));

        user.PasswordHash.Should().Be(originalPasswordHash);

        user.IsActive.Should().BeTrue();
    }

    [Fact]
    public void SetIdentityId_ShouldUpdateValue()
    {
        var user = UserData.CreateUser();

        user.SetIdentityId("auth0|123456");

        user.IdentityId.Should().Be("auth0|123456");
    }

    [Fact]
    public void SetIdentityId_ShouldNotRaiseDomainEvent()
    {
        var user = UserData.CreateUser();

        user.ClearDomainEvents();

        user.SetIdentityId("auth0|123456");

        user.GetDomainEvents().Should().BeEmpty();
    }

    [Fact]
    public void SetIdentityId_ShouldOverwriteExistingValue()
    {
        var user = UserData.CreateUser();

        user.SetIdentityId("old");

        user.SetIdentityId("new");

        user.IdentityId.Should().Be("new");
    }
}