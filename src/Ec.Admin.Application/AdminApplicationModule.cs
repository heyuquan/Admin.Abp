using Ec.Admin.Application.Contracts;
using Ec.Admin.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Ec.Admin.Application
{
    [DependsOn(
        typeof(AdminApplicationContractsModule),
        typeof(AdminDomainModule),
        typeof(AbpAutoMapperModule),
        // module
        typeof(AbpAccountApplicationModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule)
        )]
    public class AdminApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AdminApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AdminApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
