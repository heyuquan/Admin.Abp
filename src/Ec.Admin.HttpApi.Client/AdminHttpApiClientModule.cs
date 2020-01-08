using Ec.Admin.Application.Contracts;
using System;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ec.Admin.HttpApi.Client
{
    [DependsOn(
        typeof(AdminApplicationContractsModule),
        // module
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule)
        )]
    public class AdminHttpApiClientModule
    {
    }
}
