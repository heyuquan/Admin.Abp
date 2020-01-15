using Ec.Admin.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Ec.Admin.IdentityServer
{
    // 引入 Ec.Admin.Application.Contracts 的原因
    // 因为它 引入了 Volo.Abp.Identity.Application.Contracts
    // 其中 IdentityPermissionDefinitionProvider.cs 文件定义了默认权限，需要依赖注入到程序中


    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AdminApplicationContractsModule),
        typeof(AdminIdentityServerEntityFrameworkCoreDbMigrationsModule)        
        )]
    public class AdminIdentityServerDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
