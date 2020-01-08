using Ec.Admin.Domain.Shared;
using Ec.Admin.Domain.Shared.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace Ec.Admin.Domain
{
    [DependsOn(
        typeof(AdminDomainSharedModule)
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
