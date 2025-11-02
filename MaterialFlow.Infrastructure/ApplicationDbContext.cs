using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Domain.Users;
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
using MaterialFlow.Infrastructure.Outbox;

namespace MaterialFlow.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<RolePermission> RolePermissions { get; set; }

    public DbSet<ComponentReservation> ComponentReservations { get; set; }

    public DbSet<ForecastPlan> ForecastPlans { get; set; }

    public DbSet<ForecastPlanItem> ForecastPlanItems { get; set; }

    public DbSet<InventoryBalance> InventoryBalances { get; set; }

    public DbSet<Material> Materials { get; set; }

    public DbSet<PlannedProductionOrder> PlannedProductionOrders { get; set; }

    public DbSet<PlanningArea> PlanningAreas { get; set; }

    public DbSet<PlanningRun> PlanningRuns { get; set; }

    public DbSet<PlanningRunLine> PlanningRunLines { get; set; }

    public DbSet<ProductComponent> ProductComponents { get; set; }

    public DbSet<ProductStructure> ProductStructures { get; set; }

    public DbSet<ProductionOrder> ProductionOrders { get; set; }

    public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public DbSet<SalesOrderDemand> SalesOrderDemands { get; set; }

    public DbSet<Site> Sites { get; set; }

    public DbSet<StorageLocation> StorageLocations { get; set; }

    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}