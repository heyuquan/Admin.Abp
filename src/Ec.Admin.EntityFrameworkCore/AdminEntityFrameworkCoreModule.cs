using Ec.Admin.AggregateRoot;
using Ec.Admin.Repository;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Ec.Admin
{
    [DependsOn(
        typeof(AdminDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        // module
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule)
        )]
    public class AdminEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AdminDbContext>(options=> {
                options.AddDefaultRepositories();

                // 默认情况下为每个“聚合根实体(AggregateRoot派生的子类)”创建一个仓储. 
                // 如果想要为“实体(Entity派生的子类)”也创建仓储 请将includeAllEntities 设置为 true:
                //options.AddDefaultRepositories(includeAllEntities: true);

                // 覆盖默认通用仓储
                options.AddRepository<Role, RoleRepository>();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}
