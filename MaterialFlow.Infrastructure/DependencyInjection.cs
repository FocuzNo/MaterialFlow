using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Domain.ComponentReservations;
using MaterialFlow.Domain.ForecastPlanItems;
using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.InventoryBalances;
using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.PlannedProductionOrders;
using MaterialFlow.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaterialFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration
            .GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());

        services.AddScoped<IMaterialRepository, MaterialRepository>();

        services.AddScoped<IForecastPlanRepository, ForecastPlanRepository>();

        services.AddScoped<IForecastPlanItemRepository, ForecastPlanItemRepository>();

        services.AddScoped<IComponentReservationRepository, ComponentReservationRepository>();

        services.AddScoped<IInventoryBalanceRepository, InventoryBalanceRepository>();

        services.AddScoped<IPlannedProductionOrderRepository, PlannedProductionOrderRepository>();

        services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(typeof(ApplicationDbContext).Assembly));

        services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
