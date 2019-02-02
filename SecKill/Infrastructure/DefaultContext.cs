using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace SecKill.Infrastructure
{
    /// <summary>
    /// 数据上下文 (一次数据会话)
    /// </summary>
    public class DefaultContext : DbContext
    {

        public DefaultContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 通过反射区查找实现了IEntityTypeConfiguration<> 的类并循环应用配置
            var implementedConfigTypes = Assembly.GetExecutingAssembly()
                                                 .GetTypes()
                                                 .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetTypeInfo().ImplementedInterfaces.Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configType in implementedConfigTypes)
            {
                dynamic config = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(config);
            }
        }

        /// <summary>
        /// 创建一个默认的EF上下文 EFCoreDesign 表示通过Entity生成数据库
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        public static DefaultContext CreateForEFCoreDesign(string connstr)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var options = optionsBuilder.UseSqlServer(connstr).Options;
            return new DefaultContext(options);
        }
    }
}
