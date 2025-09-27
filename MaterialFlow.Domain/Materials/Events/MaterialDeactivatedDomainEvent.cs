namespace MaterialFlow.Domain.Materials.Events;

public sealed record MaterialDeactivatedDomainEvent(Guid MaterialId) : IDomainEvent;