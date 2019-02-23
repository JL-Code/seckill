﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecKill.Infrastructure;

namespace SecKill.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecKill.Domain.AggregatesModel.Goods", b =>
                {
                    b.Property<Guid>("GoodsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GoodsName");

                    b.Property<string>("PictureUrl");

                    b.Property<double>("Price");

                    b.Property<int>("StockCount");

                    b.HasKey("GoodsId");

                    b.ToTable("Goods");

                    b.HasData(
                        new
                        {
                            GoodsId = new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"),
                            GoodsName = "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）",
                            PictureUrl = "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png",
                            Price = 5999.0,
                            StockCount = 10
                        });
                });

            modelBuilder.Entity("SecKill.Domain.AggregatesModel.SeckillGoods", b =>
                {
                    b.Property<Guid>("SeckillGoodsId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<Guid>("GoodsId");

                    b.Property<string>("GoodsName");

                    b.Property<string>("PictureUrl");

                    b.Property<int>("Quantity");

                    b.Property<double>("SeckillPrice");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("SeckillGoodsId");

                    b.ToTable("SeckillGoods");

                    b.HasData(
                        new
                        {
                            SeckillGoodsId = new Guid("dd1669dc-c714-4da5-9e3a-da3d862999d0"),
                            EndDate = new DateTime(2019, 2, 23, 22, 23, 14, 686, DateTimeKind.Local).AddTicks(7247),
                            GoodsId = new Guid("b266ade2-ff83-44d3-aa60-128ab17dbf43"),
                            GoodsName = "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）",
                            PictureUrl = "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png",
                            Quantity = 10,
                            SeckillPrice = 9.9000000000000004,
                            StartDate = new DateTime(2019, 2, 23, 21, 23, 14, 688, DateTimeKind.Local).AddTicks(552)
                        });
                });

            modelBuilder.Entity("SecKill.Domain.AggregatesModel.SeckillOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<Guid>("GoodsId");

                    b.Property<string>("GoodsName");

                    b.Property<double>("GoodsPrice");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.Property<int>("OrderState");

                    b.Property<string>("PaymentTerms");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("UserId");

                    b.HasKey("OrderId");

                    b.ToTable("SeckillOrder");
                });

            modelBuilder.Entity("SecKill.Domain.AggregatesModel.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e205e0f7-4b9c-4f9a-a554-ac3df63af6e1"),
                            Address = "长江国际",
                            Password = "1",
                            UserName = "jiangy"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
