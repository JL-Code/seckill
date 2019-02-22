using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations.MySQLMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsId = table.Column<byte[]>(nullable: false),
                    GoodsName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    StockCount = table.Column<int>(nullable: false),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsId);
                });

            migrationBuilder.CreateTable(
                name: "SeckillGoods",
                columns: table => new
                {
                    SeckillGoodsId = table.Column<byte[]>(nullable: false),
                    GoodsId = table.Column<byte[]>(nullable: false),
                    GoodsName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SeckillPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeckillGoods", x => x.SeckillGoodsId);
                });

            migrationBuilder.CreateTable(
                name: "SeckillOrder",
                columns: table => new
                {
                    OrderId = table.Column<byte[]>(nullable: false),
                    OrderState = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    PaymentTerms = table.Column<string>(nullable: true),
                    GoodsId = table.Column<byte[]>(nullable: false),
                    GoodsPrice = table.Column<double>(nullable: false),
                    GoodsName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeckillOrder", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "GoodsId", "GoodsName", "Img", "Price", "StockCount" },
                values: new object[] { new byte[] { 226, 173, 102, 178, 131, 255, 211, 68, 170, 96, 18, 138, 177, 125, 191, 67 }, "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 5999.0, 10 });

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "Img", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new byte[] { 178, 87, 221, 178, 245, 39, 27, 65, 182, 66, 139, 166, 56, 252, 153, 175 }, new DateTime(2019, 2, 22, 14, 30, 15, 842, DateTimeKind.Local).AddTicks(1990), new byte[] { 226, 173, 102, 178, 131, 255, 211, 68, 170, 96, 18, 138, 177, 125, 191, 67 }, "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 22, 13, 30, 15, 846, DateTimeKind.Local).AddTicks(2340) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new byte[] { 70, 135, 65, 248, 70, 83, 199, 71, 170, 225, 173, 46, 169, 98, 65, 131 }, "长江国际", null, "1", "jiangy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "SeckillGoods");

            migrationBuilder.DropTable(
                name: "SeckillOrder");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
