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
            builder.ToTable("User").HasData(new User
            {
                UserId = Guid.NewGuid(),
                UserName = "jiangy",
                Password = "1",
                Address = "长江国际"
            });
        }
    }
}
