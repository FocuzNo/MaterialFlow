using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "storage_locations",
                newName: "storage_locations",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "sites",
                newName: "sites",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "sales_order_demands",
                newName: "sales_order_demands",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "roles",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "role_user",
                newName: "role_user",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "role_permissions",
                newName: "role_permissions",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "purchase_requests",
                newName: "purchase_requests",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "production_orders",
                newName: "production_orders",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "product_structures",
                newName: "product_structures",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "product_components",
                newName: "product_components",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "planning_runs",
                newName: "planning_runs",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "planning_run_lines",
                newName: "planning_run_lines",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "planning_areas",
                newName: "planning_areas",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "planned_production_orders",
                newName: "planned_production_orders",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "permission",
                newName: "permission",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "outbox_messages",
                newName: "outbox_messages",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "materials",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "inventory_balances",
                newName: "inventory_balances",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "forecast_plans",
                newName: "forecast_plans",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "forecast_plan_items",
                newName: "forecast_plan_items",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "component_reservations",
                newName: "component_reservations",
                newSchema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                schema: "public",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "storage_locations",
                schema: "public",
                newName: "storage_locations");

            migrationBuilder.RenameTable(
                name: "sites",
                schema: "public",
                newName: "sites");

            migrationBuilder.RenameTable(
                name: "sales_order_demands",
                schema: "public",
                newName: "sales_order_demands");

            migrationBuilder.RenameTable(
                name: "roles",
                schema: "public",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "role_user",
                schema: "public",
                newName: "role_user");

            migrationBuilder.RenameTable(
                name: "role_permissions",
                schema: "public",
                newName: "role_permissions");

            migrationBuilder.RenameTable(
                name: "purchase_requests",
                schema: "public",
                newName: "purchase_requests");

            migrationBuilder.RenameTable(
                name: "production_orders",
                schema: "public",
                newName: "production_orders");

            migrationBuilder.RenameTable(
                name: "product_structures",
                schema: "public",
                newName: "product_structures");

            migrationBuilder.RenameTable(
                name: "product_components",
                schema: "public",
                newName: "product_components");

            migrationBuilder.RenameTable(
                name: "planning_runs",
                schema: "public",
                newName: "planning_runs");

            migrationBuilder.RenameTable(
                name: "planning_run_lines",
                schema: "public",
                newName: "planning_run_lines");

            migrationBuilder.RenameTable(
                name: "planning_areas",
                schema: "public",
                newName: "planning_areas");

            migrationBuilder.RenameTable(
                name: "planned_production_orders",
                schema: "public",
                newName: "planned_production_orders");

            migrationBuilder.RenameTable(
                name: "permission",
                schema: "public",
                newName: "permission");

            migrationBuilder.RenameTable(
                name: "outbox_messages",
                schema: "public",
                newName: "outbox_messages");

            migrationBuilder.RenameTable(
                name: "materials",
                schema: "public",
                newName: "materials");

            migrationBuilder.RenameTable(
                name: "inventory_balances",
                schema: "public",
                newName: "inventory_balances");

            migrationBuilder.RenameTable(
                name: "forecast_plans",
                schema: "public",
                newName: "forecast_plans");

            migrationBuilder.RenameTable(
                name: "forecast_plan_items",
                schema: "public",
                newName: "forecast_plan_items");

            migrationBuilder.RenameTable(
                name: "component_reservations",
                schema: "public",
                newName: "component_reservations");
        }
    }
}
