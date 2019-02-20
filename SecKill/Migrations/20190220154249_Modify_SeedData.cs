using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class Modify_SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("c012f824-0e3b-4711-b68d-31d3bec5d0d5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("10e5c4d8-3525-4354-acb9-913f03f8e298"));

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "Img", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("a17fb06a-d4b7-454a-ac7a-b73c769ed113"), new DateTime(2019, 2, 21, 0, 42, 49, 113, DateTimeKind.Local).AddTicks(6527), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 20, 23, 42, 49, 114, DateTimeKind.Local).AddTicks(9721) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("b4d7e62d-3a46-4a56-85bb-dc0d31f2b610"), "长江国际", null, "1", "jiangy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("a17fb06a-d4b7-454a-ac7a-b73c769ed113"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("b4d7e62d-3a46-4a56-85bb-dc0d31f2b610"));

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "Img", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("c012f824-0e3b-4711-b68d-31d3bec5d0d5"), new DateTime(2019, 2, 21, 0, 41, 25, 192, DateTimeKind.Local).AddTicks(2535), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 20, 23, 41, 25, 193, DateTimeKind.Local).AddTicks(6103) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("10e5c4d8-3525-4354-acb9-913f03f8e298"), "长江国际", null, "1", "jiangy" });
        }
    }
}
