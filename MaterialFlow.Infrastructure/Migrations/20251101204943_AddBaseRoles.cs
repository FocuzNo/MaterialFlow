using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_permission_permission_id",
                schema: "public",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_roles_role_id",
                schema: "public",
                table: "role_permissions");

            migrationBuilder.DropIndex(
                name: "ix_role_permissions_permission_id",
                schema: "public",
                table: "role_permissions");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                schema: "public",
                table: "permission",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "public",
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Planner" },
                    { 3, "Viewer" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_permission_role_id",
                schema: "public",
                table: "permission",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_permission_roles_role_id",
                schema: "public",
                table: "permission",
                column: "role_id",
                principalSchema: "public",
                principalTable: "roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permission_roles_role_id",
                schema: "public",
                table: "permission");

            migrationBuilder.DropIndex(
                name: "ix_permission_role_id",
                schema: "public",
                table: "permission");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "roles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "role_id",
                schema: "public",
                table: "permission");

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_permission_id",
                schema: "public",
                table: "role_permissions",
                column: "permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_permission_permission_id",
                schema: "public",
                table: "role_permissions",
                column: "permission_id",
                principalSchema: "public",
                principalTable: "permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_roles_role_id",
                schema: "public",
                table: "role_permissions",
                column: "role_id",
                principalSchema: "public",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
