namespace MaterialFlow.Domain.Materials.Events;

public sealed record MaterialCreatedDomainEvent(Guid MaterialId) : IDomainEvent;