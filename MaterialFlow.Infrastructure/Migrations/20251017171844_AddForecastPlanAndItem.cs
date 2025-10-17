using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForecastPlanAndItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "site",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    plant_code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_site", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "component_reservation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_order_type = table.Column<string>(type: "text", nullable: false),
                    source_order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requirement_date = table.Column<DateOnly>(type: "date", nullable: false),
                    quantity_amount = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_component_reservation", x => x.id);
                    table.ForeignKey(
                        name: "fk_component_reservation_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_component_reservation_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "planning_area",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    planning_area_code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_planning_area", x => x.id);
                    table.ForeignKey(
                        name: "fk_planning_area_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forecast_plan",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: true),
                    planning_area_id = table.Column<Guid>(type: "uuid", nullable: true),
                    version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    planning_strategy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    period_granularity = table.Column<int>(type: "integer", maxLength: 2, nullable: false),
                    date_range_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    date_range_end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_forecast_plan", x => x.id);
                    table.ForeignKey(
                        name: "fk_forecast_plan_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_forecast_plan_planning_area_planning_area_id",
                        column: x => x.planning_area_id,
                        principalTable: "planning_area",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_forecast_plan_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "forecast_plan_item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    forecast_plan_id = table.Column<Guid>(type: "uuid", nullable: false),
                    period_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    quantity_amount = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    consumption_indicator = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_forecast_plan_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_forecast_plan_item_forecast_plan_forecast_plan_id",
                        column: x => x.forecast_plan_id,
                        principalTable: "forecast_plan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_component_reservation_material_id",
                table: "component_reservation",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_component_reservation_site_id",
                table: "component_reservation",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_forecast_plan_material_id",
                table: "forecast_plan",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_forecast_plan_planning_area_id",
                table: "forecast_plan",
                column: "planning_area_id");

            migrationBuilder.CreateIndex(
                name: "ix_forecast_plan_site_id",
                table: "forecast_plan",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_forecast_plan_item_forecast_plan_id",
                table: "forecast_plan_item",
                column: "forecast_plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_planning_area_site_id",
                table: "planning_area",
                column: "site_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "component_reservation");

            migrationBuilder.DropTable(
                name: "forecast_plan_item");

            migrationBuilder.DropTable(
                name: "forecast_plan");

            migrationBuilder.DropTable(
                name: "planning_area");

            migrationBuilder.DropTable(
                name: "site");
        }
    }
}
