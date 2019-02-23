using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecKill.Domain.AggregatesModel;
using System;

namespace SecKill.Infrastructure.EntityConfigurations
{
    public class SeckillGoodsConfiguration : IEntityTypeConfiguration<SeckillGoods>
    {
        public void Configure(EntityTypeBuilder<SeckillGoods> builder)
        {
            // TODO: 如何同时为 SqlServer 和 MySql 两种数据库配置列

            builder.HasKey(m => m.SeckillGoodsId);
            builder.ToTable("SeckillGoods").HasData(new SeckillGoods
            {
                GoodsId = new Guid("B266ADE2-FF83-44D3-AA60-128AB17DBF43"),
                GoodsName = "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）",
                EndDate = DateTime.Now.AddMinutes(60),
                StartDate = DateTime.Now,
                PictureUrl = "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png",
                Quantity = 10,
                SeckillGoodsId = Guid.NewGuid(),
                SeckillPrice = 9.9
            });
        }
    }
}
