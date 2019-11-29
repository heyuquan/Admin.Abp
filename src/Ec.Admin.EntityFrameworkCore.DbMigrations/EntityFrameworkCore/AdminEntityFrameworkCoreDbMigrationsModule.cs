using Ec.Admin.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Ec.Admin.EntityFrameworkCore
{
    [DependsOn(
        typeof(AdminEntityFrameworkCoreSqlServerModule)
        )]
    public class AdminEntityFrameworkCoreDbMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AdminMigrationsDbContext>();
        }
    }
}
