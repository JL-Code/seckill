using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class Add_Data_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Goods",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "GoodsId", "GoodsName", "Img", "Price", "StockCount" },
                values: new object[] { new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 5999.0, 10 });

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "Img", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("aef28bc9-a728-40ca-ad0b-138f4dcee772"), new DateTime(2019, 2, 20, 22, 24, 15, 510, DateTimeKind.Local).AddTicks(2665), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 20, 21, 24, 15, 511, DateTimeKind.Local).AddTicks(5926) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("3ad6ac2c-3baf-4bc1-ab4d-c96ae87c4928"), "长江国际", null, "1", "jiangy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Goods",
                keyColumn: "GoodsId",
                keyValue: new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"));

            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("aef28bc9-a728-40ca-ad0b-138f4dcee772"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("3ad6ac2c-3baf-4bc1-ab4d-c96ae87c4928"));

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Goods");
        }
    }
}
