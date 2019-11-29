using Ec.Admin.Application.Contracts;
using Ec.Admin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Ec.Admin.Application
{
    [DependsOn(
        typeof(AdminApplicationContractsModule),
        typeof(AdminDomainModule)
        )]
    public class AdminApplicationModule : AbpModule
    {
    }
}
