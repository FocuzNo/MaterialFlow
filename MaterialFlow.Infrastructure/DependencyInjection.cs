using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Application.Abstractions.Caching;
using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Domain.ComponentReservations;
using MaterialFlow.Domain.ForecastPlanItems;
using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.InventoryBalances;
using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.PlannedProductionOrders;
using MaterialFlow.Domain.PlanningAreas;
using MaterialFlow.Domain.PlanningRunLines;
using MaterialFlow.Domain.PlanningRuns;
using MaterialFlow.Domain.ProductComponents;
using MaterialFlow.Domain.ProductionOrders;
using MaterialFlow.Domain.ProductStructures;
using MaterialFlow.Domain.PurchaseRequests;
using MaterialFlow.Domain.SalesOrderDemands;
using MaterialFlow.Domain.Sites;
using MaterialFlow.Domain.Users;
using MaterialFlow.Infrastructure.Authentication;
using MaterialFlow.Infrastructure.Authorization;
using MaterialFlow.Infrastructure.Caching;
using MaterialFlow.Infrastructure.Repositories;
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
        AddPersistence(services, configuration);

        AddCaching(services, configuration);

        AddAuthentication(services, configuration);

        AddAuthorization(services);

        return services;
    }

    private static void AddPersistence(
        IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString)
                   .UseSnakeCaseNamingConvention());

        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IForecastPlanRepository, ForecastPlanRepository>();
        services.AddScoped<IForecastPlanItemRepository, ForecastPlanItemRepository>();
        services.AddScoped<IComponentReservationRepository, ComponentReservationRepository>();
        services.AddScoped<IInventoryBalanceRepository, InventoryBalanceRepository>();
        services.AddScoped<IPlannedProductionOrderRepository, PlannedProductionOrderRepository>();
        services.AddScoped<ISiteRepository, SiteRepository>();
        services.AddScoped<ISalesOrderDemandRepository, SalesOrderDemandRepository>();
        services.AddScoped<IPurchaseRequestRepository, PurchaseRequestRepository>();
        services.AddScoped<IProductStructureRepository, ProductStructureRepository>();
        services.AddScoped<IProductionOrderRepository, ProductionOrderRepository>();
        services.AddScoped<IProductComponentRepository, ProductComponentRepository>();
        services.AddScoped<IPlanningRunRepository, PlanningRunRepository>();
        services.AddScoped<IPlanningRunLineRepository, PlanningRunLineRepository>();
        services.AddScoped<IPlanningAreaRepository, PlanningAreaRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationDbContext).Assembly));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "http://materialflow-idp:8080/realms/materialflow";
                options.Audience = "materialflow-api";
                options.RequireHttpsMetadata = false;
            });

        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));

        services.Configure<KeycloakOptions>(configuration.GetSection("Keycloak"));

        services.AddTransient<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IAuthenticationService, AuthenticationService>((serviceProvider, httpClient) =>
        {
            KeycloakOptions keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;

            httpClient.BaseAddress = new Uri(keycloakOptions.AdminUrl);
        })
        .AddHttpMessageHandler<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IJwtService, JwtService>((serviceProvider, httpClient) =>
        {
            KeycloakOptions keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;

            httpClient.BaseAddress = new Uri(keycloakOptions.TokenUrl);
        });

        services.AddHttpContextAccessor();

        services.AddScoped<IUserContext, UserContext>();
    }

    private static void AddAuthorization(IServiceCollection services)
    {
        services.AddScoped<AuthorizationService>();

        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();

        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
    }

    private static void AddCaching(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Cache") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);

        services.AddSingleton<ICacheService, CacheService>();
    }
}
