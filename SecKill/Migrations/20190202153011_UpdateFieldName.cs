using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class UpdateFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_goods",
                table: "goods");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "goods",
                newName: "Goods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goods",
                table: "Goods",
                column: "GoodsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goods",
                table: "Goods");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Goods",
                newName: "goods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_goods",
                table: "goods",
                column: "GoodsId");
        }
    }
}
