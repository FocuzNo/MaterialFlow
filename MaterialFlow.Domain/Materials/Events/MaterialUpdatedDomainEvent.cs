namespace MaterialFlow.Domain.Materials.Events;

public sealed record MaterialUpdatedDomainEvent(Guid MaterialId) : IDomainEvent;