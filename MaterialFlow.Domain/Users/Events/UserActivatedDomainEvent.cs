namespace MaterialFlow.Domain.Users.Events;

public sealed record UserActivatedDomainEvent(Guid UserId) : IDomainEvent;