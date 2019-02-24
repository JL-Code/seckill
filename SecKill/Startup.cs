using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.EntityFrameworkCore.Extensions;
using SecKill.Application.Services;
using SecKill.Domain.AggregatesModel;
using SecKill.Domain.SeedWork;
using SecKill.Infrastructure;
using SecKill.Infrastructure.Repositories;
using System;
using System.Text;

namespace SecKill
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // 通过依赖注入注册数据库上下文
            //services.AddSqlServerDbContext(Configuration).AddMySQLDbContext(Configuration);
            services.AddSqlServerDbContext(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region 添加 Jwt token Authentication 认证方案

            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       NameClaimType = "name",
                       ValidIssuer = " http://192.168.31.110:8082", //jwtSettings.Issuer,
                       ValidAudience = " http://192.168.31.110:8082",//jwtSettings.Audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtOptions.Constants.SECRET_KEY))
                       /***********************************TokenValidationParameters的参数默认值***********************************/
                       // RequireSignedTokens = true,
                       // SaveSigninToken = false,
                       // ValidateActor = false,
                       // 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                       // ValidateAudience = true,
                       // ValidateIssuer = true, 
                       // ValidateIssuerSigningKey = false,
                       // 是否要求Token的Claims中必须包含Expires
                       // RequireExpirationTime = true,
                       // 允许的服务器时间偏移量
                       // ClockSkew = TimeSpan.FromSeconds(300),
                       // 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                       // ValidateLifetime = true
                   };
               });

            #endregion

            #region We will Repository and Service Register to DI

            // transient scope singleton 三者的区别

            services.AddTransient<ISeckillGoodsService, SeckillGoodsService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ISeckillGoodsRepository, SeckillGoodsRepository>();
            services.AddTransient<ISecKillOrderRepository, SecKillOrderRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(new RedisManager("localhost"));

            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // 启用身份认证
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }

    /// <summary>
    /// 自定义扩展方法
    /// </summary>
    static class CustomExtensionsMethods
    {
        /// <summary>
        /// 添加自定义数据上下文
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlServerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connstr = configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<DefaultContext>(options =>
                   {
                       options.UseSqlServer(connstr, sqlServerOptionsAction: sqlOptions =>
                       {
                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       });
                   },
                       //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                       ServiceLifetime.Scoped
                   );
            return services;
        }

        public static IServiceCollection AddMySQLDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connstr = configuration.GetConnectionString("MySQLConnection");
            services.AddEntityFrameworkMySQL()
                   .AddDbContext<MysqlDbContext>(options =>
                   {
                       options.UseMySQL(connstr);
                   },
                       //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                       ServiceLifetime.Scoped
                   );
            return services;
        }
    }
}
