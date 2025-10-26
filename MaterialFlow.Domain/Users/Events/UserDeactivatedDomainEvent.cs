namespace MaterialFlow.Domain.Users.Events;

public sealed record UserDeactivatedDomainEvent(Guid UserId) : IDomainEvent;