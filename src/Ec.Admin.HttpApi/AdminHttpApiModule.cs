using Ec.Admin.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;

namespace Ec.Admin.HttpApi
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
