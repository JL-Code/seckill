using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class SeckillGoods_Add_Img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "SeckillGoods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "SeckillGoods");
        }
    }
}
