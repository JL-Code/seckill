using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class SeckillGoods_Drop_Quantity_Add_StockCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("dd1669dc-c714-4da5-9e3a-da3d862999d0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("e205e0f7-4b9c-4f9a-a554-ac3df63af6e1"));

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "SeckillGoods",
                newName: "StockCount");

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "PictureUrl", "SeckillPrice", "StartDate", "StockCount" },
                values: new object[] { new Guid("a3bfcbed-da5a-48f8-9a24-95f533acaf5e"), new DateTime(2019, 2, 24, 19, 34, 3, 378, DateTimeKind.Local).AddTicks(7471), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 9.9000000000000004, new DateTime(2019, 2, 24, 18, 34, 3, 380, DateTimeKind.Local).AddTicks(707), 10 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("0838b2b9-62e2-4f96-9c59-0ad26714f466"), "长江国际", null, "1", "jiangy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("a3bfcbed-da5a-48f8-9a24-95f533acaf5e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("0838b2b9-62e2-4f96-9c59-0ad26714f466"));

            migrationBuilder.RenameColumn(
                name: "StockCount",
                table: "SeckillGoods",
                newName: "Quantity");

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "PictureUrl", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("dd1669dc-c714-4da5-9e3a-da3d862999d0"), new DateTime(2019, 2, 23, 22, 23, 14, 686, DateTimeKind.Local).AddTicks(7247), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 23, 21, 23, 14, 688, DateTimeKind.Local).AddTicks(552) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("e205e0f7-4b9c-4f9a-a554-ac3df63af6e1"), "长江国际", null, "1", "jiangy" });
        }
    }
}
