using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolesAndPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_role_permission_permission_permission_id",
                table: "role_permission");

            migrationBuilder.DropForeignKey(
                name: "fk_role_permission_role_role_id",
                table: "role_permission");

            migrationBuilder.DropForeignKey(
                name: "fk_role_user_role_roles_id",
                table: "role_user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_permission",
                table: "role_permission");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role",
                table: "role");

            migrationBuilder.RenameTable(
                name: "role_permission",
                newName: "role_permissions");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "roles");

            migrationBuilder.RenameIndex(
                name: "ix_role_permission_permission_id",
                table: "role_permissions",
                newName: "ix_role_permissions_permission_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_permissions",
                table: "role_permissions",
                columns: new[] { "role_id", "permission_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_permission_permission_id",
                table: "role_permissions",
                column: "permission_id",
                principalTable: "permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_roles_role_id",
                table: "role_permissions",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_user_roles_roles_id",
                table: "role_user",
                column: "roles_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_permission_permission_id",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_roles_role_id",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_role_user_roles_roles_id",
                table: "role_user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_permissions",
                table: "role_permissions");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "role_permissions",
                newName: "role_permission");

            migrationBuilder.RenameIndex(
                name: "ix_role_permissions_permission_id",
                table: "role_permission",
                newName: "ix_role_permission_permission_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role",
                table: "role",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_permission",
                table: "role_permission",
                columns: new[] { "role_id", "permission_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_role_permission_permission_permission_id",
                table: "role_permission",
                column: "permission_id",
                principalTable: "permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_permission_role_role_id",
                table: "role_permission",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_user_role_roles_id",
                table: "role_user",
                column: "roles_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
