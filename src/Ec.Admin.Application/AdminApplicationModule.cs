using Ec.Admin.Application.Contracts;
using Ec.Admin.Domain;
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
