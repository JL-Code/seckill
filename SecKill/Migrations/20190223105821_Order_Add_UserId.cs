using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecKill.Migrations
{
    public partial class Order_Add_UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("d367405e-ad38-4cc2-9153-b78938f527f5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("2def6484-b0b4-4976-960c-45432dcc229d"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SeckillOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "PictureUrl", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("01d9c264-6542-4c09-bd14-4021bfa58be0"), new DateTime(2019, 2, 23, 19, 58, 20, 839, DateTimeKind.Local).AddTicks(6575), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 23, 18, 58, 20, 840, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("104258e1-0936-46e8-bde0-cea2d0f49062"), "长江国际", null, "1", "jiangy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeckillGoods",
                keyColumn: "SeckillGoodsId",
                keyValue: new Guid("01d9c264-6542-4c09-bd14-4021bfa58be0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("104258e1-0936-46e8-bde0-cea2d0f49062"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SeckillOrder");

            migrationBuilder.InsertData(
                table: "SeckillGoods",
                columns: new[] { "SeckillGoodsId", "EndDate", "GoodsId", "GoodsName", "PictureUrl", "Quantity", "SeckillPrice", "StartDate" },
                values: new object[] { new Guid("d367405e-ad38-4cc2-9153-b78938f527f5"), new DateTime(2019, 2, 22, 0, 30, 57, 191, DateTimeKind.Local).AddTicks(260), new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"), "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）", "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png", 10, 9.9000000000000004, new DateTime(2019, 2, 21, 23, 30, 57, 192, DateTimeKind.Local).AddTicks(3791) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName" },
                values: new object[] { new Guid("2def6484-b0b4-4976-960c-45432dcc229d"), "长江国际", null, "1", "jiangy" });
        }
    }
}
