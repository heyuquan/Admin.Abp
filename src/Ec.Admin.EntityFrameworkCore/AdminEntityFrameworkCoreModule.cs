using Ec.Admin.Domain;
using Ec.Admin.Domain.AggregateRoot;
using Ec.Admin.EntityFrameworkCore.Repository;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Ec.Admin.EntityFrameworkCore
{
    [DependsOn(
        typeof(AdminDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        // module
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule)
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
