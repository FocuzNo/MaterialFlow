using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetForEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_component_reservation_material_material_id",
                table: "component_reservation");

            migrationBuilder.DropForeignKey(
                name: "fk_component_reservation_site_site_id",
                table: "component_reservation");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plan_material_material_id",
                table: "forecast_plan");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plan_planning_area_planning_area_id",
                table: "forecast_plan");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plan_site_site_id",
                table: "forecast_plan");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plan_item_forecast_plan_forecast_plan_id",
                table: "forecast_plan_item");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_balance_material_material_id",
                table: "inventory_balance");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_balance_site_site_id",
                table: "inventory_balance");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_balance_storage_location_storage_location_id",
                table: "inventory_balance");

            migrationBuilder.DropForeignKey(
                name: "fk_planned_production_order_material_material_id",
                table: "planned_production_order");

            migrationBuilder.DropForeignKey(
                name: "fk_planned_production_order_planning_run_planning_run_id",
                table: "planned_production_order");

            migrationBuilder.DropForeignKey(
                name: "fk_planned_production_order_site_site_id",
                table: "planned_production_order");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_area_site_site_id",
                table: "planning_area");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_planning_area_planning_area_id",
                table: "planning_run");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_site_site_id",
                table: "planning_run");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_line_material_material_id",
                table: "planning_run_line");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_line_planning_run_planning_run_id",
                table: "planning_run_line");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_line_site_site_id",
                table: "planning_run_line");

            migrationBuilder.DropForeignKey(
                name: "fk_product_component_material_material_id",
                table: "product_component");

            migrationBuilder.DropForeignKey(
                name: "fk_product_component_product_structure_product_structure_id",
                table: "product_component");

            migrationBuilder.DropForeignKey(
                name: "fk_product_structure_material_material_id",
                table: "product_structure");

            migrationBuilder.DropForeignKey(
                name: "fk_product_structure_site_site_id",
                table: "product_structure");

            migrationBuilder.DropForeignKey(
                name: "fk_production_order_material_material_id",
                table: "production_order");

            migrationBuilder.DropForeignKey(
                name: "fk_production_order_planned_production_order_planned_productio",
                table: "production_order");

            migrationBuilder.DropForeignKey(
                name: "fk_production_order_site_site_id",
                table: "production_order");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_request_material_material_id",
                table: "purchase_request");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_request_planning_run_planning_run_id",
                table: "purchase_request");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_request_site_site_id",
                table: "purchase_request");

            migrationBuilder.DropForeignKey(
                name: "fk_sales_order_demand_material_material_id",
                table: "sales_order_demand");

            migrationBuilder.DropForeignKey(
                name: "fk_sales_order_demand_site_site_id",
                table: "sales_order_demand");

            migrationBuilder.DropForeignKey(
                name: "fk_storage_location_site_site_id",
                table: "storage_location");

            migrationBuilder.DropPrimaryKey(
                name: "pk_storage_location",
                table: "storage_location");

            migrationBuilder.DropPrimaryKey(
                name: "pk_site",
                table: "site");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sales_order_demand",
                table: "sales_order_demand");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_request",
                table: "purchase_request");

            migrationBuilder.DropPrimaryKey(
                name: "pk_production_order",
                table: "production_order");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_structure",
                table: "product_structure");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_component",
                table: "product_component");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planning_run_line",
                table: "planning_run_line");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planning_run",
                table: "planning_run");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planning_area",
                table: "planning_area");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planned_production_order",
                table: "planned_production_order");

            migrationBuilder.DropPrimaryKey(
                name: "pk_material",
                table: "material");

            migrationBuilder.DropPrimaryKey(
                name: "pk_inventory_balance",
                table: "inventory_balance");

            migrationBuilder.DropPrimaryKey(
                name: "pk_forecast_plan_item",
                table: "forecast_plan_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_forecast_plan",
                table: "forecast_plan");

            migrationBuilder.DropPrimaryKey(
                name: "pk_component_reservation",
                table: "component_reservation");

            migrationBuilder.RenameTable(
                name: "storage_location",
                newName: "storage_locations");

            migrationBuilder.RenameTable(
                name: "site",
                newName: "sites");

            migrationBuilder.RenameTable(
                name: "sales_order_demand",
                newName: "sales_order_demands");

            migrationBuilder.RenameTable(
                name: "purchase_request",
                newName: "purchase_requests");

            migrationBuilder.RenameTable(
                name: "production_order",
                newName: "production_orders");

            migrationBuilder.RenameTable(
                name: "product_structure",
                newName: "product_structures");

            migrationBuilder.RenameTable(
                name: "product_component",
                newName: "product_components");

            migrationBuilder.RenameTable(
                name: "planning_run_line",
                newName: "planning_run_lines");

            migrationBuilder.RenameTable(
                name: "planning_run",
                newName: "planning_runs");

            migrationBuilder.RenameTable(
                name: "planning_area",
                newName: "planning_areas");

            migrationBuilder.RenameTable(
                name: "planned_production_order",
                newName: "planned_production_orders");

            migrationBuilder.RenameTable(
                name: "material",
                newName: "materials");

            migrationBuilder.RenameTable(
                name: "inventory_balance",
                newName: "inventory_balances");

            migrationBuilder.RenameTable(
                name: "forecast_plan_item",
                newName: "forecast_plan_items");

            migrationBuilder.RenameTable(
                name: "forecast_plan",
                newName: "forecast_plans");

            migrationBuilder.RenameTable(
                name: "component_reservation",
                newName: "component_reservations");

            migrationBuilder.RenameIndex(
                name: "ix_storage_location_site_id",
                table: "storage_locations",
                newName: "ix_storage_locations_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_site_plant_code",
                table: "sites",
                newName: "ix_sites_plant_code");

            migrationBuilder.RenameIndex(
                name: "ix_sales_order_demand_site_id",
                table: "sales_order_demands",
                newName: "ix_sales_order_demands_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_sales_order_demand_material_id",
                table: "sales_order_demands",
                newName: "ix_sales_order_demands_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_request_site_id",
                table: "purchase_requests",
                newName: "ix_purchase_requests_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_request_planning_run_id",
                table: "purchase_requests",
                newName: "ix_purchase_requests_planning_run_id");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_request_material_id",
                table: "purchase_requests",
                newName: "ix_purchase_requests_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_production_order_site_id",
                table: "production_orders",
                newName: "ix_production_orders_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_production_order_planned_production_order_id",
                table: "production_orders",
                newName: "ix_production_orders_planned_production_order_id");

            migrationBuilder.RenameIndex(
                name: "ix_production_order_material_id",
                table: "production_orders",
                newName: "ix_production_orders_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_structure_site_id",
                table: "product_structures",
                newName: "ix_product_structures_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_structure_material_id",
                table: "product_structures",
                newName: "ix_product_structures_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_component_product_structure_id",
                table: "product_components",
                newName: "ix_product_components_product_structure_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_component_material_id",
                table: "product_components",
                newName: "ix_product_components_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_line_site_id",
                table: "planning_run_lines",
                newName: "ix_planning_run_lines_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_line_planning_run_id",
                table: "planning_run_lines",
                newName: "ix_planning_run_lines_planning_run_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_line_material_id",
                table: "planning_run_lines",
                newName: "ix_planning_run_lines_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_site_id",
                table: "planning_runs",
                newName: "ix_planning_runs_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_planning_area_id",
                table: "planning_runs",
                newName: "ix_planning_runs_planning_area_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_area_site_id",
                table: "planning_areas",
                newName: "ix_planning_areas_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planned_production_order_site_id",
                table: "planned_production_orders",
                newName: "ix_planned_production_orders_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planned_production_order_planning_run_id",
                table: "planned_production_orders",
                newName: "ix_planned_production_orders_planning_run_id");

            migrationBuilder.RenameIndex(
                name: "ix_planned_production_order_material_id",
                table: "planned_production_orders",
                newName: "ix_planned_production_orders_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_inventory_balance_storage_location_id",
                table: "inventory_balances",
                newName: "ix_inventory_balances_storage_location_id");

            migrationBuilder.RenameIndex(
                name: "ix_inventory_balance_site_id",
                table: "inventory_balances",
                newName: "ix_inventory_balances_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_inventory_balance_material_id",
                table: "inventory_balances",
                newName: "ix_inventory_balances_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plan_item_forecast_plan_id",
                table: "forecast_plan_items",
                newName: "ix_forecast_plan_items_forecast_plan_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plan_site_id",
                table: "forecast_plans",
                newName: "ix_forecast_plans_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plan_planning_area_id",
                table: "forecast_plans",
                newName: "ix_forecast_plans_planning_area_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plan_material_id",
                table: "forecast_plans",
                newName: "ix_forecast_plans_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_component_reservation_site_id",
                table: "component_reservations",
                newName: "ix_component_reservations_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_component_reservation_material_id",
                table: "component_reservations",
                newName: "ix_component_reservations_material_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_storage_locations",
                table: "storage_locations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sites",
                table: "sites",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sales_order_demands",
                table: "sales_order_demands",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_requests",
                table: "purchase_requests",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_production_orders",
                table: "production_orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_structures",
                table: "product_structures",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_components",
                table: "product_components",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planning_run_lines",
                table: "planning_run_lines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planning_runs",
                table: "planning_runs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planning_areas",
                table: "planning_areas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planned_production_orders",
                table: "planned_production_orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_materials",
                table: "materials",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_inventory_balances",
                table: "inventory_balances",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_forecast_plan_items",
                table: "forecast_plan_items",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_forecast_plans",
                table: "forecast_plans",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_component_reservations",
                table: "component_reservations",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_component_reservations_materials_material_id",
                table: "component_reservations",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_component_reservations_sites_site_id",
                table: "component_reservations",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plan_items_forecast_plans_forecast_plan_id",
                table: "forecast_plan_items",
                column: "forecast_plan_id",
                principalTable: "forecast_plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plans_materials_material_id",
                table: "forecast_plans",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plans_planning_areas_planning_area_id",
                table: "forecast_plans",
                column: "planning_area_id",
                principalTable: "planning_areas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plans_sites_site_id",
                table: "forecast_plans",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_balances_materials_material_id",
                table: "inventory_balances",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_balances_sites_site_id",
                table: "inventory_balances",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_balances_storage_locations_storage_location_id",
                table: "inventory_balances",
                column: "storage_location_id",
                principalTable: "storage_locations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_planned_production_orders_materials_material_id",
                table: "planned_production_orders",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planned_production_orders_planning_runs_planning_run_id",
                table: "planned_production_orders",
                column: "planning_run_id",
                principalTable: "planning_runs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_planned_production_orders_sites_site_id",
                table: "planned_production_orders",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_areas_sites_site_id",
                table: "planning_areas",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_lines_materials_material_id",
                table: "planning_run_lines",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_lines_planning_runs_planning_run_id",
                table: "planning_run_lines",
                column: "planning_run_id",
                principalTable: "planning_runs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_lines_sites_site_id",
                table: "planning_run_lines",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_runs_planning_areas_planning_area_id",
                table: "planning_runs",
                column: "planning_area_id",
                principalTable: "planning_areas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_planning_runs_sites_site_id",
                table: "planning_runs",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_components_materials_material_id",
                table: "product_components",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_components_product_structures_product_structure_id",
                table: "product_components",
                column: "product_structure_id",
                principalTable: "product_structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_structures_materials_material_id",
                table: "product_structures",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_structures_sites_site_id",
                table: "product_structures",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_production_orders_materials_material_id",
                table: "production_orders",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_production_orders_planned_production_orders_planned_product",
                table: "production_orders",
                column: "planned_production_order_id",
                principalTable: "planned_production_orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_production_orders_sites_site_id",
                table: "production_orders",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_requests_materials_material_id",
                table: "purchase_requests",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_requests_planning_runs_planning_run_id",
                table: "purchase_requests",
                column: "planning_run_id",
                principalTable: "planning_runs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_requests_sites_site_id",
                table: "purchase_requests",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sales_order_demands_materials_material_id",
                table: "sales_order_demands",
                column: "material_id",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sales_order_demands_sites_site_id",
                table: "sales_order_demands",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_storage_locations_sites_site_id",
                table: "storage_locations",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_component_reservations_materials_material_id",
                table: "component_reservations");

            migrationBuilder.DropForeignKey(
                name: "fk_component_reservations_sites_site_id",
                table: "component_reservations");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plan_items_forecast_plans_forecast_plan_id",
                table: "forecast_plan_items");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plans_materials_material_id",
                table: "forecast_plans");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plans_planning_areas_planning_area_id",
                table: "forecast_plans");

            migrationBuilder.DropForeignKey(
                name: "fk_forecast_plans_sites_site_id",
                table: "forecast_plans");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_balances_materials_material_id",
                table: "inventory_balances");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_balances_sites_site_id",
                table: "inventory_balances");

            migrationBuilder.DropForeignKey(
                name: "fk_inventory_balances_storage_locations_storage_location_id",
                table: "inventory_balances");

            migrationBuilder.DropForeignKey(
                name: "fk_planned_production_orders_materials_material_id",
                table: "planned_production_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_planned_production_orders_planning_runs_planning_run_id",
                table: "planned_production_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_planned_production_orders_sites_site_id",
                table: "planned_production_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_areas_sites_site_id",
                table: "planning_areas");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_lines_materials_material_id",
                table: "planning_run_lines");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_lines_planning_runs_planning_run_id",
                table: "planning_run_lines");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_run_lines_sites_site_id",
                table: "planning_run_lines");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_runs_planning_areas_planning_area_id",
                table: "planning_runs");

            migrationBuilder.DropForeignKey(
                name: "fk_planning_runs_sites_site_id",
                table: "planning_runs");

            migrationBuilder.DropForeignKey(
                name: "fk_product_components_materials_material_id",
                table: "product_components");

            migrationBuilder.DropForeignKey(
                name: "fk_product_components_product_structures_product_structure_id",
                table: "product_components");

            migrationBuilder.DropForeignKey(
                name: "fk_product_structures_materials_material_id",
                table: "product_structures");

            migrationBuilder.DropForeignKey(
                name: "fk_product_structures_sites_site_id",
                table: "product_structures");

            migrationBuilder.DropForeignKey(
                name: "fk_production_orders_materials_material_id",
                table: "production_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_production_orders_planned_production_orders_planned_product",
                table: "production_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_production_orders_sites_site_id",
                table: "production_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_requests_materials_material_id",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_requests_planning_runs_planning_run_id",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_requests_sites_site_id",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "fk_sales_order_demands_materials_material_id",
                table: "sales_order_demands");

            migrationBuilder.DropForeignKey(
                name: "fk_sales_order_demands_sites_site_id",
                table: "sales_order_demands");

            migrationBuilder.DropForeignKey(
                name: "fk_storage_locations_sites_site_id",
                table: "storage_locations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_storage_locations",
                table: "storage_locations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sites",
                table: "sites");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sales_order_demands",
                table: "sales_order_demands");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase_requests",
                table: "purchase_requests");

            migrationBuilder.DropPrimaryKey(
                name: "pk_production_orders",
                table: "production_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_structures",
                table: "product_structures");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_components",
                table: "product_components");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planning_runs",
                table: "planning_runs");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planning_run_lines",
                table: "planning_run_lines");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planning_areas",
                table: "planning_areas");

            migrationBuilder.DropPrimaryKey(
                name: "pk_planned_production_orders",
                table: "planned_production_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_materials",
                table: "materials");

            migrationBuilder.DropPrimaryKey(
                name: "pk_inventory_balances",
                table: "inventory_balances");

            migrationBuilder.DropPrimaryKey(
                name: "pk_forecast_plans",
                table: "forecast_plans");

            migrationBuilder.DropPrimaryKey(
                name: "pk_forecast_plan_items",
                table: "forecast_plan_items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_component_reservations",
                table: "component_reservations");

            migrationBuilder.RenameTable(
                name: "storage_locations",
                newName: "storage_location");

            migrationBuilder.RenameTable(
                name: "sites",
                newName: "site");

            migrationBuilder.RenameTable(
                name: "sales_order_demands",
                newName: "sales_order_demand");

            migrationBuilder.RenameTable(
                name: "purchase_requests",
                newName: "purchase_request");

            migrationBuilder.RenameTable(
                name: "production_orders",
                newName: "production_order");

            migrationBuilder.RenameTable(
                name: "product_structures",
                newName: "product_structure");

            migrationBuilder.RenameTable(
                name: "product_components",
                newName: "product_component");

            migrationBuilder.RenameTable(
                name: "planning_runs",
                newName: "planning_run");

            migrationBuilder.RenameTable(
                name: "planning_run_lines",
                newName: "planning_run_line");

            migrationBuilder.RenameTable(
                name: "planning_areas",
                newName: "planning_area");

            migrationBuilder.RenameTable(
                name: "planned_production_orders",
                newName: "planned_production_order");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "material");

            migrationBuilder.RenameTable(
                name: "inventory_balances",
                newName: "inventory_balance");

            migrationBuilder.RenameTable(
                name: "forecast_plans",
                newName: "forecast_plan");

            migrationBuilder.RenameTable(
                name: "forecast_plan_items",
                newName: "forecast_plan_item");

            migrationBuilder.RenameTable(
                name: "component_reservations",
                newName: "component_reservation");

            migrationBuilder.RenameIndex(
                name: "ix_storage_locations_site_id",
                table: "storage_location",
                newName: "ix_storage_location_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_sites_plant_code",
                table: "site",
                newName: "ix_site_plant_code");

            migrationBuilder.RenameIndex(
                name: "ix_sales_order_demands_site_id",
                table: "sales_order_demand",
                newName: "ix_sales_order_demand_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_sales_order_demands_material_id",
                table: "sales_order_demand",
                newName: "ix_sales_order_demand_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_requests_site_id",
                table: "purchase_request",
                newName: "ix_purchase_request_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_requests_planning_run_id",
                table: "purchase_request",
                newName: "ix_purchase_request_planning_run_id");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_requests_material_id",
                table: "purchase_request",
                newName: "ix_purchase_request_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_production_orders_site_id",
                table: "production_order",
                newName: "ix_production_order_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_production_orders_planned_production_order_id",
                table: "production_order",
                newName: "ix_production_order_planned_production_order_id");

            migrationBuilder.RenameIndex(
                name: "ix_production_orders_material_id",
                table: "production_order",
                newName: "ix_production_order_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_structures_site_id",
                table: "product_structure",
                newName: "ix_product_structure_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_structures_material_id",
                table: "product_structure",
                newName: "ix_product_structure_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_components_product_structure_id",
                table: "product_component",
                newName: "ix_product_component_product_structure_id");

            migrationBuilder.RenameIndex(
                name: "ix_product_components_material_id",
                table: "product_component",
                newName: "ix_product_component_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_runs_site_id",
                table: "planning_run",
                newName: "ix_planning_run_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_runs_planning_area_id",
                table: "planning_run",
                newName: "ix_planning_run_planning_area_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_lines_site_id",
                table: "planning_run_line",
                newName: "ix_planning_run_line_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_lines_planning_run_id",
                table: "planning_run_line",
                newName: "ix_planning_run_line_planning_run_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_run_lines_material_id",
                table: "planning_run_line",
                newName: "ix_planning_run_line_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_planning_areas_site_id",
                table: "planning_area",
                newName: "ix_planning_area_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planned_production_orders_site_id",
                table: "planned_production_order",
                newName: "ix_planned_production_order_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_planned_production_orders_planning_run_id",
                table: "planned_production_order",
                newName: "ix_planned_production_order_planning_run_id");

            migrationBuilder.RenameIndex(
                name: "ix_planned_production_orders_material_id",
                table: "planned_production_order",
                newName: "ix_planned_production_order_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_inventory_balances_storage_location_id",
                table: "inventory_balance",
                newName: "ix_inventory_balance_storage_location_id");

            migrationBuilder.RenameIndex(
                name: "ix_inventory_balances_site_id",
                table: "inventory_balance",
                newName: "ix_inventory_balance_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_inventory_balances_material_id",
                table: "inventory_balance",
                newName: "ix_inventory_balance_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plans_site_id",
                table: "forecast_plan",
                newName: "ix_forecast_plan_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plans_planning_area_id",
                table: "forecast_plan",
                newName: "ix_forecast_plan_planning_area_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plans_material_id",
                table: "forecast_plan",
                newName: "ix_forecast_plan_material_id");

            migrationBuilder.RenameIndex(
                name: "ix_forecast_plan_items_forecast_plan_id",
                table: "forecast_plan_item",
                newName: "ix_forecast_plan_item_forecast_plan_id");

            migrationBuilder.RenameIndex(
                name: "ix_component_reservations_site_id",
                table: "component_reservation",
                newName: "ix_component_reservation_site_id");

            migrationBuilder.RenameIndex(
                name: "ix_component_reservations_material_id",
                table: "component_reservation",
                newName: "ix_component_reservation_material_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_storage_location",
                table: "storage_location",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_site",
                table: "site",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sales_order_demand",
                table: "sales_order_demand",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase_request",
                table: "purchase_request",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_production_order",
                table: "production_order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_structure",
                table: "product_structure",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_component",
                table: "product_component",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planning_run",
                table: "planning_run",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planning_run_line",
                table: "planning_run_line",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planning_area",
                table: "planning_area",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_planned_production_order",
                table: "planned_production_order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_material",
                table: "material",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_inventory_balance",
                table: "inventory_balance",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_forecast_plan",
                table: "forecast_plan",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_forecast_plan_item",
                table: "forecast_plan_item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_component_reservation",
                table: "component_reservation",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_component_reservation_material_material_id",
                table: "component_reservation",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_component_reservation_site_site_id",
                table: "component_reservation",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plan_material_material_id",
                table: "forecast_plan",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plan_planning_area_planning_area_id",
                table: "forecast_plan",
                column: "planning_area_id",
                principalTable: "planning_area",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plan_site_site_id",
                table: "forecast_plan",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_forecast_plan_item_forecast_plan_forecast_plan_id",
                table: "forecast_plan_item",
                column: "forecast_plan_id",
                principalTable: "forecast_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_balance_material_material_id",
                table: "inventory_balance",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_balance_site_site_id",
                table: "inventory_balance",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inventory_balance_storage_location_storage_location_id",
                table: "inventory_balance",
                column: "storage_location_id",
                principalTable: "storage_location",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_planned_production_order_material_material_id",
                table: "planned_production_order",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planned_production_order_planning_run_planning_run_id",
                table: "planned_production_order",
                column: "planning_run_id",
                principalTable: "planning_run",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_planned_production_order_site_site_id",
                table: "planned_production_order",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_area_site_site_id",
                table: "planning_area",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_planning_area_planning_area_id",
                table: "planning_run",
                column: "planning_area_id",
                principalTable: "planning_area",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_site_site_id",
                table: "planning_run",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_line_material_material_id",
                table: "planning_run_line",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_line_planning_run_planning_run_id",
                table: "planning_run_line",
                column: "planning_run_id",
                principalTable: "planning_run",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_planning_run_line_site_site_id",
                table: "planning_run_line",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_component_material_material_id",
                table: "product_component",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_component_product_structure_product_structure_id",
                table: "product_component",
                column: "product_structure_id",
                principalTable: "product_structure",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_structure_material_material_id",
                table: "product_structure",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_structure_site_site_id",
                table: "product_structure",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_production_order_material_material_id",
                table: "production_order",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_production_order_planned_production_order_planned_productio",
                table: "production_order",
                column: "planned_production_order_id",
                principalTable: "planned_production_order",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_production_order_site_site_id",
                table: "production_order",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_request_material_material_id",
                table: "purchase_request",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_request_planning_run_planning_run_id",
                table: "purchase_request",
                column: "planning_run_id",
                principalTable: "planning_run",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_request_site_site_id",
                table: "purchase_request",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sales_order_demand_material_material_id",
                table: "sales_order_demand",
                column: "material_id",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sales_order_demand_site_site_id",
                table: "sales_order_demand",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_storage_location_site_site_id",
                table: "storage_location",
                column: "site_id",
                principalTable: "site",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
