using Ec.Admin.Application;
using Ec.Admin.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using StackExchange.Redis;
using Microsoft.AspNetCore.DataProtection;

namespace Ec.Admin.HttpApi
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AdminApplicationModule),
        // 需要依赖框架的 AbpAspNetCoreModule ，进行aspnetcore相关的依赖注入
        typeof(AbpAspNetCoreModule),
        // 注册 Controller相关服务
        typeof(AbpAspNetCoreMvcModule),
        typeof(AdminEntityFrameworkCoreModule),
        // 注册cache模块，可以使用volo.Abp.Cache封装的缓存操作接口
        typeof(AbpCachingModule)
        )]
    public class AdminHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureConventionalControllers();

            ConfigureCache(configuration);
            ConfigureRedis(context, configuration, hostingEnvironment);

            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AdminApplicationModule).Assembly);
            });
        }

        private void ConfigureCache(IConfiguration configuration)
        {
            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "Ec.Admin:";
            });
        }

        private void ConfigureRedis(
            ServiceConfigurationContext context,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment
            )
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            if (!hostingEnvironment.IsDevelopment())
            {
                var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
                context.Services
                    .AddDataProtection()
                    .PersistKeysToStackExchangeRedis(redis, "Ec.Admin-Protection-Keys");
            }
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ec.Admin API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ec.Admin API");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
