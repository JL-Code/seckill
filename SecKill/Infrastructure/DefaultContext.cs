using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
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
        /// <summary>
        ///  日志工厂
        /// </summary>
        public static readonly LoggerFactory MyLoggerFactory
        = new LoggerFactory(new[] {
             new ConsoleLoggerProvider((category, level)  => 
               category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information, true)
        });

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            base.OnConfiguring(optionsBuilder);
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
