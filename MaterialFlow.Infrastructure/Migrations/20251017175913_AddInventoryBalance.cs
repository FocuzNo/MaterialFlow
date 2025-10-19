using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storage_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_storage_location", x => x.id);
                    table.ForeignKey(
                        name: "fk_storage_location_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory_balance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    site_id = table.Column<Guid>(type: "uuid", nullable: false),
                    storage_location_id = table.Column<Guid>(type: "uuid", nullable: true),
                    on_hand_amount = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    on_hand_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    reserved_amount = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    reserved_unit_of_measure_value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    batch = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inventory_balance", x => x.id);
                    table.ForeignKey(
                        name: "fk_inventory_balance_material_material_id",
                        column: x => x.material_id,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_balance_site_site_id",
                        column: x => x.site_id,
                        principalTable: "site",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_balance_storage_location_storage_location_id",
                        column: x => x.storage_location_id,
                        principalTable: "storage_location",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_inventory_balance_material_id",
                table: "inventory_balance",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_balance_site_id",
                table: "inventory_balance",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_balance_storage_location_id",
                table: "inventory_balance",
                column: "storage_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_storage_location_site_id",
                table: "storage_location",
                column: "site_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_balance");

            migrationBuilder.DropTable(
                name: "storage_location");
        }
    }
}
