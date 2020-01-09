using Ec.Admin.Application;
using Ec.Admin.Application.Contracts;
using Ec.Admin.Domain;
using Ec.Admin.Domain.Shared;
using Ec.Admin.Domain.Shared.Localization;
using Ec.Admin.Domain.Shared.MultiTenancy;
using Ec.Admin.EntityFrameworkCore;
using Ec.Admin.HttpApi;
using Ec.Admin.Web.Menus;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace Ec.Admin.Web
{
    [DependsOn(
        typeof(AdminHttpApiModule),
        typeof(AdminApplicationModule),
        typeof(AdminEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        // 需要依赖框架的 AbpAspNetCoreModule ，进行aspnetcore相关的依赖注入
        typeof(AbpAspNetCoreModule),
        // 注册 Controller相关服务
        typeof(AbpAspNetCoreMvcModule),
        // 注册ui相关（abp扩展taghelper、多租户、bundling、ui主题）
        typeof(AbpAspNetCoreMvcUiBootstrapModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpAspNetCoreMvcUiBundlingModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        // 注册cache模块，可以使用volo.Abp.Cache封装的缓存操作接口
        typeof(AbpCachingModule),
        // 多语言
        typeof(AbpLocalizationModule),
        // module
        typeof(AbpAccountWebModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpPermissionManagementWebModule)
        )]
    public class AdminWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(AdminResource),
                    typeof(AdminDomainModule).Assembly,
                    typeof(AdminDomainSharedModule).Assembly,
                    typeof(AdminApplicationModule).Assembly,
                    typeof(AdminApplicationContractsModule).Assembly,
                    typeof(AdminWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigureIdentityAuthentication(context, configuration);
            ConfigAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:selfUrl"];
            });
        }

        private void ConfigureIdentityAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            // 有如下AbpIdentity定义后，还需要在 OnApplicationInitialization 中调用：app.UseAuthentication();
            context.Services.AddAbpIdentity();

            context.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = System.TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";               
                options.SlidingExpiration = true;
            });            
        }

        private void ConfigAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AdminWebModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<AdminDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Ec.Admin.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AdminDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Ec.Admin.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AdminApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Ec.Admin.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AdminApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Ec.Admin.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AdminWebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AdminResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AdminMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            // 自动API控制器
            // 如果一个类实现了IRemoteService接口, 那么它会被自动选择为API控制器
            // [RemoteService(IsEnabled = false)] 禁用自动生成
            // 默认情况下, HTTP API控制器会自动启用API Explorer,可通过[RemoteService(IsMetadataEnabled = false)]隐藏它
            // swagger中隐藏服务. 但是它仍然可以被知道确切API路由的客户端使用.


            // 包含类 AdminApplicationModule 的程序集中的所有应用程序服务
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers
                    .Create(typeof(AdminApplicationModule).Assembly, opts =>
                    {
                        //路由
                        //    它始终以 / api开头.
                        //    接着是路由路径.默认值为"/app", 可以进行如下配置:
                        // 默认为 api/app/**   可通过下面方式修改
                        // opts.RootPath = "volosoft/book-store";
                    });
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ec.Admin.Web", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            app.UseCorrelationId();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
            }
            
            app.UseVirtualFiles();
            app.UseRouting();
            // 认证
            app.UseAuthentication();
            // 授权
            //app.UseAuthorization();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAbpRequestLocalization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ec.Admin.Web API");
            });

            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
