using Ec.Admin.Domain.Shared;
using Ec.Admin.Domain.Shared.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace Ec.Admin.Domain
{
    [DependsOn(
        typeof(AdminDomainSharedModule),
        // module
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainModule)
        )]
    public class AdminDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }
    }
}
