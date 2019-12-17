using Ec.Admin.Application;
using Ec.Admin.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

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
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureConventionalControllers();
            ConfigureCors(context, configuration);

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

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", System.StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix(""))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        // 设置策略的 IsOriginAllowed 属性，使可以匹配一个带通配符的域名
                        // eg: .WithOrigins("https://*.cnblogs.com", "http://*.cnblogs.com")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
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

            app.UseCorrelationId();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            //app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ec.Admin API");
            });

            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
