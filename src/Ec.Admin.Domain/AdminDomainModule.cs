using Ec.Admin.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;

namespace Ec.Admin
{
    [DependsOn(
        typeof(AdminDomainSharedModule),
        // module
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule)
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
