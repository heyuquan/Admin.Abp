using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Http.Client;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Ec.Admin
{
    [DependsOn(
        typeof(AdminApplicationContractsModule),
        typeof(AbpHttpClientModule),
        // module   
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule)
        )]
    public class AdminHttpApiClientModule: AbpModule
    {
        public const string RemoteServiceName = "AdminRemoteService";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AdminApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }

    }
}
