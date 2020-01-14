using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;

namespace Ec.Admin
{
    [DependsOn(
        typeof(AdminApplicationContractsModule),
        // module
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule)
        )]
    public class AdminHttpApiModule : AbpModule
    {
    }
}
