using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;
#pragma warning disable IDE0161
#pragma warning disable IDE0053

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_Application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_todo_items_users_user_id",
                schema: "public",
                table: "todo_items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_todo_items",
                schema: "public",
                table: "todo_items");

            migrationBuilder.RenameTable(
                name: "todo_items",
                schema: "public",
                newName: "todo_item",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "ix_todo_items_user_id",
                schema: "public",
                table: "todo_item",
                newName: "ix_todo_item_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_todo_item",
                schema: "public",
                table: "todo_item",
                column: "id");

            migrationBuilder.CreateTable(
                name: "applications",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<BigInteger>(type: "numeric", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    client_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    client_secret = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    redirect_url = table.Column<string>(type: "text", nullable: false),
                    api_base_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    application_status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_applications", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_todo_item_users_user_id",
                schema: "public",
                table: "todo_item",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_todo_item_users_user_id",
                schema: "public",
                table: "todo_item");

            migrationBuilder.DropTable(
                name: "applications",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "pk_todo_item",
                schema: "public",
                table: "todo_item");

            migrationBuilder.RenameTable(
                name: "todo_item",
                schema: "public",
                newName: "todo_items",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "ix_todo_item_user_id",
                schema: "public",
                table: "todo_items",
                newName: "ix_todo_items_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_todo_items",
                schema: "public",
                table: "todo_items",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_todo_items_users_user_id",
                schema: "public",
                table: "todo_items",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
#pragma warning restore IDE0161
#pragma warning restore IDE0053
