using MaterialFlow.Domain.Abstractions;

namespace MaterialFlow.Domain.UnitTests.Infrastructure;

public abstract class BaseTest
{
    protected static T AssertDomainEventWasPublished<T>(Entity entity) where T : IDomainEvent
    {
        var domainEvent = entity
            .GetDomainEvents()
            .OfType<T>()
            .SingleOrDefault();

        return domainEvent ?? throw new InvalidOperationException($"Domain event {typeof(T).Name} was not published.");
    }
}