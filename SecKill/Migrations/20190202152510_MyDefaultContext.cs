using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class MyDefaultContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "goods",
                columns: table => new
                {
                    GoodsId = table.Column<Guid>(nullable: false),
                    GoodsName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    StockCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goods", x => x.GoodsId);
                });

            migrationBuilder.CreateTable(
                name: "SeckillGoods",
                columns: table => new
                {
                    SeckillGoodsId = table.Column<Guid>(nullable: false),
                    GoodsId = table.Column<Guid>(nullable: false),
                    GoodsName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SeckillPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeckillGoods", x => x.SeckillGoodsId);
                });

            migrationBuilder.CreateTable(
                name: "SeckillOrder",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    OrderState = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    PaymentTerms = table.Column<string>(nullable: true),
                    GoodsPrice = table.Column<double>(nullable: false),
                    GoodsName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeckillOrder", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goods");

            migrationBuilder.DropTable(
                name: "SeckillGoods");

            migrationBuilder.DropTable(
                name: "SeckillOrder");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
