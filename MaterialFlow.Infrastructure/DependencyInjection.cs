using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Application.Abstractions.Caching;
using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Infrastructure.Authentication;
using MaterialFlow.Infrastructure.Authorization;
using MaterialFlow.Infrastructure.Caching;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using AuthenticationOptions = MaterialFlow.Infrastructure.Authentication.AuthenticationOptions;
using AuthenticationService = MaterialFlow.Infrastructure.Authentication.AuthenticationService;
using IAuthenticationService = MaterialFlow.Application.Abstractions.Authentication.IAuthenticationService;

namespace MaterialFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddCaching(configuration)
            .AddAuthentication(configuration)
            .AddAuthorization();

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());

        services.Scan(scan => scan
            .FromAssemblyOf<ApplicationDbContext>()
            .AddClasses(c => c.Where(t => t.Name.EndsWith("Repository")), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationDbContext).Assembly));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }

    private static IServiceCollection AddCaching(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var cacheConnection = configuration.GetConnectionString("Cache")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(opts => opts.Configuration = cacheConnection);
        services.AddSingleton<ICacheService, CacheService>();

        return services;
    }

    private static IServiceCollection AddAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opts =>
            {
                opts.Authority = "http://materialflow-idp:8080/realms/materialflow";
                opts.Audience = "materialflow-api";
                opts.RequireHttpsMetadata = false;
            });

        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));
        services.Configure<KeycloakOptions>(configuration.GetSection("Keycloak"));

        services.AddTransient<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IAuthenticationService, AuthenticationService>(static (sp, client) =>
        {
            var opts = sp.GetRequiredService<IOptions<KeycloakOptions>>().Value;
            client.BaseAddress = new Uri(opts.AdminUrl);
        }).AddHttpMessageHandler<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IJwtService, JwtService>(static (sp, client) =>
        {
            var opts = sp.GetRequiredService<IOptions<KeycloakOptions>>().Value;
            client.BaseAddress = new Uri(opts.TokenUrl);
        });

        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();

        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services
            .AddScoped<AuthorizationService>()
            .AddTransient<IClaimsTransformation, CustomClaimsTransformation>()
            .AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>()
            .AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        return services;
    }
}