using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "plant_code",
                table: "site",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "site",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "planning_area_code",
                table: "planning_area",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "planning_area",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "reserved_amount",
                table: "inventory_balance",
                type: "numeric(21,3)",
                precision: 21,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "on_hand_amount",
                table: "inventory_balance",
                type: "numeric(21,3)",
                precision: 21,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "quantity_amount",
                table: "forecast_plan_item",
                type: "numeric(21,3)",
                precision: 21,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<string>(
                name: "source_order_type",
                table: "component_reservation",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "planning_run",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    run_timestamp_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: true),
                    planning_area_id = table.Column<Guid>(type: "uuid", nullable: true),
                    planning_horizon_in_days = table.Column<int>(type: "integer", nullable: false),
                    started_by_user = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    order_status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_planning_run", x => x.id);
                    table.ForeignKey(
                        name: "fk_planning_run_planning_area_planning_area_id",
                        column: x => x.planning_area_id,
                        principalTable: "planning_area",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_planning_run_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_structure",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: true),
                    usage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    alternative_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    valid_from_date = table.Column<DateOnly>(type: "date", nullable: false),
                    valid_to_date = table.Column<DateOnly>(type: "date", nullable: true),
                    order_status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_structure", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_structure_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_structure_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sales_order_demand",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requirement_date = table.Column<DateOnly>(type: "date", nullable: false),
                    quantity_amount = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    source_document_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    source_document_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    source_document_item_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sales_order_demand", x => x.id);
                    table.ForeignKey(
                        name: "fk_sales_order_demand_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sales_order_demand_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "planned_production_order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    planning_run_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    order_status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_planned_production_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_planned_production_order_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_planned_production_order_planning_run_planning_run_id",
                        column: x => x.planning_run_id,
                        principalTable: "planning_run",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_planned_production_order_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "planning_run_line",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    planning_run_id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requirement_date = table.Column<DateOnly>(type: "date", nullable: false),
                    requirement_quantity_amount = table.Column<decimal>(type: "numeric(21,3)", precision: 21, scale: 3, nullable: false),
                    requirement_quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    available_quantity_amount = table.Column<decimal>(type: "numeric(21,3)", precision: 21, scale: 3, nullable: false),
                    available_quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    shortage_quantity_amount = table.Column<decimal>(type: "numeric(21,3)", precision: 21, scale: 3, nullable: false),
                    shortage_quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    recommended_action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    reschedule_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_planning_run_line", x => x.id);
                    table.ForeignKey(
                        name: "fk_planning_run_line_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_planning_run_line_planning_run_planning_run_id",
                        column: x => x.planning_run_id,
                        principalTable: "planning_run",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_planning_run_line_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase_request",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    planning_run_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity_amount = table.Column<decimal>(type: "numeric(21,3)", precision: 21, scale: 3, nullable: false),
                    quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    requested_delivery_date = table.Column<DateOnly>(type: "date", nullable: false),
                    purchasing_group = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    order_status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchase_request", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchase_request_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchase_request_planning_run_planning_run_id",
                        column: x => x.planning_run_id,
                        principalTable: "planning_run",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchase_request_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_component",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_structure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    quantity_per_amount = table.Column<decimal>(type: "numeric(21,3)", precision: 21, scale: 3, nullable: false),
                    quantity_per_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    scrap_percentage = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_component", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_component_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_component_product_structure_product_structure_id",
                        column: x => x.product_structure_id,
                        principalTable: "product_structure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "production_order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    planned_production_order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity_to_produce_amount = table.Column<decimal>(type: "numeric(21,3)", precision: 21, scale: 3, nullable: false),
                    quantity_to_produce_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    scheduled_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    scheduled_end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    order_status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_production_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_production_order_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_production_order_planned_production_order_planned_productio",
                        column: x => x.planned_production_order_id,
                        principalTable: "planned_production_order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_production_order_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_site_plant_code",
                table: "site",
                column: "plant_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_planned_production_order_material_id",
                table: "planned_production_order",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_planned_production_order_planning_run_id",
                table: "planned_production_order",
                column: "planning_run_id");

            migrationBuilder.CreateIndex(
                name: "ix_planned_production_order_site_id",
                table: "planned_production_order",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_planning_run_planning_area_id",
                table: "planning_run",
                column: "planning_area_id");

            migrationBuilder.CreateIndex(
                name: "ix_planning_run_site_id",
                table: "planning_run",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_planning_run_line_material_id",
                table: "planning_run_line",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_planning_run_line_planning_run_id",
                table: "planning_run_line",
                column: "planning_run_id");

            migrationBuilder.CreateIndex(
                name: "ix_planning_run_line_site_id",
                table: "planning_run_line",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_component_material_id",
                table: "product_component",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_component_product_structure_id",
                table: "product_component",
                column: "product_structure_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_structure_material_id",
                table: "product_structure",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_structure_site_id",
                table: "product_structure",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_production_order_material_id",
                table: "production_order",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_production_order_planned_production_order_id",
                table: "production_order",
                column: "planned_production_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_production_order_site_id",
                table: "production_order",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_request_material_id",
                table: "purchase_request",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_request_planning_run_id",
                table: "purchase_request",
                column: "planning_run_id");

            migrationBuilder.CreateIndex(
                name: "ix_purchase_request_site_id",
                table: "purchase_request",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_sales_order_demand_material_id",
                table: "sales_order_demand",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_sales_order_demand_site_id",
                table: "sales_order_demand",
                column: "site_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planning_run_line");

            migrationBuilder.DropTable(
                name: "product_component");

            migrationBuilder.DropTable(
                name: "production_order");

            migrationBuilder.DropTable(
                name: "purchase_request");

            migrationBuilder.DropTable(
                name: "sales_order_demand");

            migrationBuilder.DropTable(
                name: "product_structure");

            migrationBuilder.DropTable(
                name: "planned_production_order");

            migrationBuilder.DropTable(
                name: "planning_run");

            migrationBuilder.DropIndex(
                name: "ix_site_plant_code",
                table: "site");

            migrationBuilder.AlterColumn<string>(
                name: "plant_code",
                table: "site",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "site",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "planning_area_code",
                table: "planning_area",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "planning_area",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<decimal>(
                name: "reserved_amount",
                table: "inventory_balance",
                type: "numeric(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(21,3)",
                oldPrecision: 21,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "on_hand_amount",
                table: "inventory_balance",
                type: "numeric(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(21,3)",
                oldPrecision: 21,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "quantity_amount",
                table: "forecast_plan_item",
                type: "numeric(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(21,3)",
                oldPrecision: 21,
                oldScale: 3);

            migrationBuilder.AlterColumn<string>(
                name: "source_order_type",
                table: "component_reservation",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
