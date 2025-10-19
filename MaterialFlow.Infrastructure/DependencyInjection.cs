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

        services.AddScoped<ISiteRepository, SiteRepository>();

        services.AddScoped<ISalesOrderDemandRepository, SalesOrderDemandRepository>();

        services.AddScoped<IPurchaseRequestRepository, PurchaseRequestRepository>();

        services.AddScoped<IProductStructureRepository, ProductStructureRepository>();

        services.AddScoped<IProductionOrderRepository, ProductionOrderRepository>();

        services.AddScoped<IProductComponentRepository, ProductComponentRepository>();

        services.AddScoped<IPlanningRunRepository, PlanningRunRepository>();

        services.AddScoped<IPlanningRunLineRepository, PlanningRunLineRepository>();

        services.AddScoped<IPlanningAreaRepository, PlanningAreaRepository>();

        services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(typeof(ApplicationDbContext).Assembly));

        services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
