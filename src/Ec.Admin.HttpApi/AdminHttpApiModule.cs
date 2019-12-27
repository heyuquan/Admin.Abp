using Ec.Admin.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Ec.Admin.HttpApi
{
    [DependsOn(
        typeof(AdminApplicationContractsModule)
        )]
    public class AdminHttpApiModule : AbpModule
    {
    }
}
