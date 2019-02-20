using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecKill.Domain.AggregatesModel;
using System;

namespace SecKill.Infrastructure.EntityConfigurations
{
    public class GoodsConfiguration : IEntityTypeConfiguration<Goods>
    {
        public void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.HasKey(m => m.GoodsId);
            builder.ToTable("Goods").HasData(new Goods
            {
                GoodsId = new Guid("B266ADE2-FF83-44D3-AA60-128AB17DBF43"),
                GoodsName = "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）",
                Img = "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png",
                Price = 5999.0,
                StockCount = 10
            });
        }
    }
}
