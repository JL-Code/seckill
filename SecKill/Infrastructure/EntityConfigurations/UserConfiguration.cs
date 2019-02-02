using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecKill.Domain.AggregatesModel;
using System;

namespace SecKill.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// 实体与表映射配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.UserId);
            builder.ToTable("User");
        }
    }

    public class GoodsConfiguration : IEntityTypeConfiguration<Goods>
    {
        public void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.HasKey(m => m.GoodsId);
            builder.ToTable("Goods");
        }
    }

    public class SeckillGoodsConfiguration : IEntityTypeConfiguration<SeckillGoods>
    {
        public void Configure(EntityTypeBuilder<SeckillGoods> builder)
        {
            builder.HasKey(m => m.SeckillGoodsId);
            builder.ToTable("SeckillGoods");
        }
    }

    // TODO: 通过Codesmith生成DDD基础代码的时候应该考虑到EF的主要版本差异
    public class SeckillOrderConfiguration : IEntityTypeConfiguration<SeckillOrder>
    {
        public void Configure(EntityTypeBuilder<SeckillOrder> builder)
        {
            builder.HasKey(m => m.OrderId);
            builder.ToTable("SeckillOrder");
        }
    }
}
