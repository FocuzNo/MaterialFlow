namespace MaterialFlow.Domain.Users.Events;

public sealed record UserPasswordChangedDomainEvent(Guid UserId) : IDomainEvent;