using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecKill.Domain.AggregatesModel;

namespace SecKill.Infrastructure.EntityConfigurations
{
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
