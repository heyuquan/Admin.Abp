using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Ec.Admin.IdentityServer.EntityFrameworkCore
{
    [DependsOn(
        typeof(AdminEntityFrameworkCoreModule)
        )]
    public class AdminIdentityServerEntityFrameworkCoreDbMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AdminMigrationsDbContext>();
        }
    }
}
