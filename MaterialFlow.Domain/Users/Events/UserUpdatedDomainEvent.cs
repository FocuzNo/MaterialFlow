namespace MaterialFlow.Domain.Users.Events;

public sealed record UserUpdatedDomainEvent(Guid UserId) : IDomainEvent;