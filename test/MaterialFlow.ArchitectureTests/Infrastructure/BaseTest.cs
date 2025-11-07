using MaterialFlow.Application.Abstractions.Messaging;
using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Infrastructure;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;

namespace MaterialFlow.ArchitectureTests.Infrastructure;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(IBaseCommand).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}