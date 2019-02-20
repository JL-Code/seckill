using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class Order_Modify_OrderState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("aef28bc9-a728-40ca-ad0b-138f4dcee772"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("3ad6ac2c-3baf-4bc1-ab4d-c96ae87c4928"));

            migrationBuilder.AlterColumn<int>(
                name: "OrderState",
                table: "SeckillOrder",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "Img", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("c012f824-0e3b-4711-b68d-31d3bec5d0d5"), new DateTime(2019, 2, 21, 0, 41, 25, 192, DateTimeKind.Local).AddTicks(2535), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 20, 23, 41, 25, 193, DateTimeKind.Local).AddTicks(6103) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("10e5c4d8-3525-4354-acb9-913f03f8e298"), "长江国际", null, "1", "jiangy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("c012f824-0e3b-4711-b68d-31d3bec5d0d5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("10e5c4d8-3525-4354-acb9-913f03f8e298"));

            migrationBuilder.AlterColumn<string>(
                name: "OrderState",
                table: "SeckillOrder",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "Img", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("aef28bc9-a728-40ca-ad0b-138f4dcee772"), new DateTime(2019, 2, 20, 22, 24, 15, 510, DateTimeKind.Local).AddTicks(2665), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 20, 21, 24, 15, 511, DateTimeKind.Local).AddTicks(5926) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("3ad6ac2c-3baf-4bc1-ab4d-c96ae87c4928"), "长江国际", null, "1", "jiangy" });
        }
    }
}
