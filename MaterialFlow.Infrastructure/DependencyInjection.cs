using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Application.Abstractions.Caching;
using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Infrastructure.Authentication;
using MaterialFlow.Infrastructure.Authorization;
using MaterialFlow.Infrastructure.Caching;
using MaterialFlow.Infrastructure.Interceptors;
using MaterialFlow.Infrastructure.Outbox;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quartz;
using AuthenticationOptions = MaterialFlow.Infrastructure.Authentication.AuthenticationOptions;
using AuthenticationService = MaterialFlow.Infrastructure.Authentication.AuthenticationService;
using IAuthenticationService = MaterialFlow.Application.Abstractions.Authentication.IAuthenticationService;

namespace MaterialFlow.Infrastructure;

public static class DependencyInjection
{
    private const string KeycloakSectionName = "Keycloak";
    private const string AuthenticationSectionName = "Authentication";
    private const string OutboxSectionName = "Outbox";

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddCaching(configuration)
            .AddHealthChecks(configuration)
            .AddBackgroundJobs(configuration)
            .AddAuthenticationServices(configuration)
            .AddAuthorizationServices();

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = GetRequiredConnectionString(configuration, "Database");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(new OutboxSaveChangesInterceptor())
                .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.Scan(scan => scan
            .FromAssemblyOf<ApplicationDbContext>()
            .AddClasses(classes => classes.Where(
                type => type.Name.EndsWith("Repository")),
                publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

    private static IServiceCollection AddCaching(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = GetRequiredConnectionString(
            configuration,
            "Cache");

        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);
        services.AddSingleton<ICacheService, CacheService>();

        return services;
    }

    private static IServiceCollection AddHealthChecks(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var keycloakBaseUrl = configuration[$"{KeycloakSectionName}:BaseUrl"]
            ?? throw new InvalidOperationException("Keycloak BaseUrl is not configured");

        services.AddHealthChecks()
            .AddNpgSql(GetRequiredConnectionString(configuration, "Database"))
            .AddRedis(GetRequiredConnectionString(configuration, "Cache"))
            .AddUrlGroup(new Uri(keycloakBaseUrl), HttpMethod.Get, "keycloak");

        return services;
    }

    private static IServiceCollection AddBackgroundJobs(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<OutboxOptions>(configuration.GetSection(OutboxSectionName));

        services.AddQuartz();
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
        services.ConfigureOptions<ProcessOutboxMessagesJobSetup>();

        return services;
    }

    private static IServiceCollection AddAuthenticationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "http://materialflow-idp:8080/realms/materialflow";
                options.Audience = "materialflow-api";
                options.RequireHttpsMetadata = false;
            });

        services.Configure<AuthenticationOptions>(configuration.GetSection(AuthenticationSectionName));
        services.Configure<KeycloakOptions>(configuration.GetSection(KeycloakSectionName));

        services.AddTransient<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IAuthenticationService, AuthenticationService>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<KeycloakOptions>>().Value;
            client.BaseAddress = new Uri(options.AdminUrl);
        }).AddHttpMessageHandler<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IJwtService, JwtService>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<KeycloakOptions>>().Value;
            client.BaseAddress = new Uri(options.TokenUrl);
        });

        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();

        return services;
    }

    private static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
    {
        services.AddScoped<AuthorizationService>();
        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();
        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        return services;
    }

    private static string GetRequiredConnectionString(IConfiguration configuration, string name)
    {
        return configuration.GetConnectionString(name)
            ?? throw new InvalidOperationException($"Connection string '{name}' is not configured");
    }
}