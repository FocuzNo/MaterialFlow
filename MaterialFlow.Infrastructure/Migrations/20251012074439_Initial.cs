using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "material",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_number_value = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    material_requirements_planning_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lot_size_policy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    procurement_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    planned_delivery_time_in_days = table.Column<int>(type: "integer", nullable: false),
                    safety_stock_quantity_amount = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    safety_stock_quantity_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_material", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "material");
        }
    }
}
