using Admin.Abp.Application.Contracts;
using Admin.Abp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Admin.Abp.Application
{
    [DependsOn(
        typeof(AdminAbpApplicationContractsModule),
        typeof(AdminAbpDomainModule)
        )]
    public class AdminAbpApplicationModule : AbpModule
    {
    }
}
